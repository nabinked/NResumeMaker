using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;
using ResumeMaker.Common;
using ResumeMaker.Services.Account;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeMaker.Controllers
{
    public class AccountController : ResumeMakerBaseController
    {
        [FromServices]
        public ISignInManager SignInManager { get; set; }

        [FromServices]
        public IPasswordService PasswordService { get; set; }

        [FromServices]
        public User UserService { get; set; }

        public AccountController()
        {

        }

        // GET: /<controller>/
        public IActionResult Login(string returnUrl = null)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var props = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };
            return new ChallengeResult(provider, props);

        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {

            var externalId = SignInManager.GetExternalIdentity("Cookies");

            // check external identity - e.g. to see if registration is required
            // or to associate account with current login etc
            // name identifier is the unique id of the user in the context of the external provider
            var nameId = externalId.Result.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = externalId.Result.FindFirst(ClaimTypes.Name).Value;
            var email = externalId.Result.FindFirst(ClaimTypes.Email).Value;


            var appUser = UserService.GetUserByEmail(email);
            if (appUser != null)
            {
                await
                    SignInManager.SignInAsync(new AppUser
                    {
                        UserName = name,
                        Email = email,
                        Id = appUser.Id
                    });

            }
            else
            {
                var newUser = new Data.Models.Core.User()
                {
                    Email = email,
                    UserName = name.Replace(" ", ""),
                    PasswordHash = PasswordService.CreateRandomPassword(6),

                };

                //Create new user in database
                var newUserId = UserService.CreateUserReturningId(newUser);
                if (newUserId > 0)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = newUser.UserName,
                        Email = newUser.Email,
                        Id = newUserId
                    };
                    await SignInManager.SignInAsync(newAppUser);
                }
            }

            //TODO delete temp cookie
            //await HttpContext.Authentication.SignOutAsync("Temp");
            return Redirect(Url.Action("Index", "Home"));
        }

        public async Task<IActionResult> LogOff()
        {
            await SignInManager.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
