using System.Collections.Generic;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Extensions;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Controllers
{
    public class ExperienceController : ResumeMakerBaseController
    {
        public IActionResult GetFormForSaveAndUpdate(long id)
        {
            var exp = new Experience();
            if (id > 0)
            {
                exp = DbContext.Experience.Get(id);
            }

            return PartialView("_ExperienceForm", exp);
        }
        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(Experience experience, string returnUrl)
        {
            if (experience.IsNew)
            {
                experience.UserId = User.GetId();
                var newEducationId = DbContext.Experience.Create(experience);


            }
            else
            {
                var upate = DbContext.Experience.Update(experience);
            }
            return Redirect(returnUrl);

        }

        public IActionResult Delete(long id, string returnUrl)
        {
            if (id > 0)
            {
                DbContext.Experience.Delete(id);
            }
            return RedirectToHomeIfReturnUrlEmpty(returnUrl);
        }

        public IActionResult GetFormForJobDescriptionSaveAndUpdate(long id, long experienceId)
        {
            var jobDescription = new JobDescription { ExperienceId = experienceId };
            if (id > 0)
            {
                jobDescription = DbContext.JobDescription.Get(id);
            }
            return PartialView("_JobDescriptionForm", jobDescription);
        }

        public IActionResult SaveUpdateJobDescription(JobDescription jobDescription, string returnUrl)
        {
            if (jobDescription.IsNew)
            {
                DbContext.JobDescription.Create(jobDescription);
                ShowToastNotification("Job Description Created",ToastEnums.ToastType.Success);

            }
            else
            {
                DbContext.JobDescription.Update(jobDescription);
                ShowToastNotification("Job Description Updated", ToastEnums.ToastType.Success);

            }

            return Redirect(returnUrl);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DeleteJobDescription(long id, string redirectUrl)
        {
            if (id > 0)
            {
                if (DbContext.JobDescription.Delete(id))
                {
                    ShowToastNotification("Job description deleted successfully.", ToastEnums.ToastType.Success);
                };

            }
            return Redirect(redirectUrl);

        }

    }
}
