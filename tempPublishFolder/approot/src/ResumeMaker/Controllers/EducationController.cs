using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Services.ToastNotification;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeMaker.Controllers
{
    [Authorize]
    public class EducationController : ResumeMakerBaseController
    {
        // GET: /<controller>/
        public IActionResult GetFormForSaveAndUpdate(long id, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var education = new Education();
            if (id > 0)
            {
                education = DbContext.Education.Get(id);
            }
            return PartialView("_EducationForm", education);
        }
        [HttpPost]
        public IActionResult SaveUpdate(Education education, string returnUrl)
        {
            if (education.IsNew)
            {
                education.UserId = User.GetId();

                if (DbContext.Education.Create(education) > 0)
                {
                    ShowSavedSuccessfullyToast();
                }
                else
                {
                    ShowTaskFailedToast();
                };


            }
            else
            {
                if (DbContext.Education.Update(education))
                {
                    ShowUpdateSuccessfullyToast();
                }
                else
                {
                    ShowTaskFailedToast();
                };
            }
            return Redirect(returnUrl);

        }

        public IActionResult Delete(long id, string returnUrl)
        {
            if (id > 0)
            {
                if (DbContext.Education.Delete(id))
                {
                    ShowDeletedSuccessfullyToast();
                }
                else
                {
                    ShowTaskFailedToast();
                };
            }
            return Redirect(returnUrl);
        }

        public EducationController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
