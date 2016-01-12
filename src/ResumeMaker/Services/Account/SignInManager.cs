using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features.Authentication;
using ResumeMaker.Common;

namespace ResumeMaker.Services.Account
{
    public class SignInManager : ISignInManager
    {
        public SignInManager(IHttpContextAccessor httpContextAccessor)
        {
            Context = httpContextAccessor.HttpContext;
        }
        public HttpContext Context { get; set; }

        public async Task SignInAsync(IAppUser user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Sid,user.Id.ToString())
                };
                var identity = new ClaimsIdentity(claims, "Basic", "name", "role");
                await Context.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(identity));
            }
        }

        public async Task LogOutAsync()
        {
            await Context.Authentication.SignOutAsync("Cookies");
        }

        public Task<ClaimsPrincipal> GetExternalIdentity(string authenticationScheme)
        {
            var auth = new AuthenticateContext(authenticationScheme);
            return Context.Authentication.AuthenticateAsync(auth.AuthenticationScheme);
        }

    }
}
