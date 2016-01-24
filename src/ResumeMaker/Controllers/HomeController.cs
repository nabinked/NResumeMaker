using Microsoft.AspNet.Mvc;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Extensions;
using ResumeMaker.Services.ToastNotification;
using ResumeMaker.ViewModels.Home;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeMaker.Controllers
{
    public class HomeController : ResumeMakerBaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            var homeViewModel = new HomeViewModel
            {
                ContactDetails =
                    DbContext.ContactDetail.Get(UserId),
                Summary = DbContext.Summary.Get(UserId),
                Objective = DbContext.Objective.Get(UserId),
                IsUserLoggedIn = User.Identity.IsAuthenticated
            };
            var db = DbContext.User.Find(x => x.Email == "nabin");
            return View(homeViewModel);
        }

        [HttpPost]
        public IActionResult SaveUpdateSummary(Summary summary, string returnUrl)
        {
            if (summary.IsNew)
            {
                summary.UserId = User.GetId();
                DbContext.Summary.Create(summary);
            }
            else
            {
                var upate = DbContext.Summary.Update(summary);
            }
            return Redirect(returnUrl);
        }
        [HttpPost]
        public IActionResult AddUpdateContact(ContactDetails contactDetails, string returnUrl)
        {
            if (contactDetails.IsNew)
            {
                contactDetails.UserId = User.GetId();
                DbContext.ContactDetail.Create(contactDetails);
            }
            else
            {
                var upate = DbContext.ContactDetail.Update(contactDetails);
            }
            return Redirect(returnUrl);
        }
        [HttpPost]
        public IActionResult AddUpdateObjective(Objective objective, string returnUrl)
        {
            if (objective.IsNew)
            {
                objective.UserId = User.GetId();
                DbContext.Objective.Create(objective);
            }
            else
            {
                var upate = DbContext.Objective.Update(objective);
            }
            return Redirect(returnUrl);
        }
    }
}
