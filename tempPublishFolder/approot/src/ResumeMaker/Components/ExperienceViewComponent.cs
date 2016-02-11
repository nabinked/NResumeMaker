using System.Linq;
using Microsoft.AspNet.Mvc;

namespace ResumeMaker.Components
{
    public class ExperienceViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var experiences = DbContext.Experience.GetAllByProperty(
                    x => x.UserId, userId).OrderByDescending(x => x.ToYear)
                    .ToList();

            return View("ExperienceView", experiences);
        }
    }
}