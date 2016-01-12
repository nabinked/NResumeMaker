using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeMaker.Controllers
{
    public class EducationController : ResumeMakerBaseController
    {
        // GET: /<controller>/
        public IActionResult GetFormForSaveAndUpdate(long id)
        {
            var education = new Education();
            if (id > 0)
            {
                education = DbContext.Education.Get(id);
            }
            return PartialView("_EducationForm", education);
        }
        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(Education education, string returnUrl)
        {
            if (education.IsNew)
            {
                education.UserId = User.GetId();
                var newEducationId = DbContext.Education.Create(education);


            }
            else
            {
                var upate = DbContext.Education.Update(education);
            }
            return Redirect(returnUrl);

        }

        public IActionResult Delete(long id, string returnUrl)
        {
            if (id > 0)
            {
                DbContext.Education.Delete(id);
            }
            return RedirectToHomeIfReturnUrlEmpty(returnUrl);
        }


    }
}
