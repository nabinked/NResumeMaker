using System.Linq;
using Microsoft.AspNet.Mvc;

namespace ResumeMaker.Components
{
    public class EducationViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var education = DbContext.Education.GetAllByProperty(
                    x => x.UserId, userId)
                    .OrderByDescending(x => x.YearOfCompletion)
                    .ToList();
            return View("EducationView", education);
        }
    }
}
