using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace ResumeMaker.Components
{
    public class KeyAccomplishmentViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long experienceId)
        {
            var jobDescription = DbContext.JobDescription.GetAllByProperty(x => x.ExperienceId, experienceId);
            return View("KeyAccomplishmentView", jobDescription);
        }
    }
}
