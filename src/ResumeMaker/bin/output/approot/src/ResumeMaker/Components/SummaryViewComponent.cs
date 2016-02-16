using Microsoft.AspNet.Mvc;

namespace ResumeMaker.Components
{
    public class SummaryViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var summary = DbContext.Summary.Find(x => x.UserId,
                    userId);
            return View("SummaryView", summary);
        }

    }
}
