using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Controllers
{
    public class SkillController : ResumeMakerBaseController
    {
        public IActionResult GetFormForSaveAndUpdate(long id, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var skill = new Skill();
            if (id > 0)
            {
                skill = DbContext.Skill.Get(id);
            }
            return PartialView("_SkillsForm", skill);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult SaveUpdate(Skill skill, string returnUrl)
        {
            if (skill.IsNew)
            {
                skill.UserId = User.GetId();
                if (DbContext.Skill.Create(skill) > 0)
                {
                    ShowSavedSuccessfullyToast();
                };


            }
            else
            {
                if (DbContext.Skill.Update(skill))
                {
                    ShowUpdateSuccessfullyToast();
                };
            }
            return Redirect(returnUrl);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id, string returnUrl)
        {
            if (id > 0)
            {
                if (DbContext.Skill.Delete(id))
                {
                    ShowDeletedSuccessfullyToast();
                };
            }
            return Redirect(returnUrl);
        }

        public SkillController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
