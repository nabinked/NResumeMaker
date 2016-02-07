using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Services.ToastNotification;
using ResumeMaker.ViewModels;

namespace ResumeMaker.Controllers
{
    public class ProfileController : ResumeMakerBaseController
    {
        public ProfileController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }

        [HttpGet("[controller]/{id:long}")]
        public IActionResult Get(long id)
        {
            var user = DbContext.User.Get(id);
            if (user != null)
            {
                ViewBag.UserCanEdit = user.Id == User.GetId();
                var profileViewModel = new ProfileViewModel {UserId = user.Id};
                return View("_Profile", profileViewModel);
            }
            else
            {
                return Redirect("");
            }

        }
    }
}
