using System;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Controllers
{
    [Authorize]
    public class ExperienceController : ResumeMakerBaseController
    {
        public IActionResult GetFormForSaveAndUpdate(long id, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
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
                if (DbContext.Experience.Create(experience) > 0)
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
                if (DbContext.Experience.Update(experience))
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
                if (DbContext.Experience.Delete(id))
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

        public IActionResult GetFormForJobDescriptionSaveAndUpdate(long id, long experienceId, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
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
                if (DbContext.JobDescription.Create(jobDescription) > 0)
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
                if (DbContext.JobDescription.Update(jobDescription))
                {
                    ShowToastNotification("Job Description Updated", ToastEnums.ToastType.Success);
                }
                else
                {
                    ShowTaskFailedToast();
                };

            }

            return Redirect(returnUrl);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DeleteJobDescription(long id, string returnUrl)
        {
            if (id > 0)
            {
                if (DbContext.JobDescription.Delete(id))
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

        public ExperienceController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
