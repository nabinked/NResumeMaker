using Microsoft.AspNet.Mvc;

namespace ResumeMaker.Components
{
    public class ObjectiveViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var objective =DbContext.Objective.Find(
                    x => x.UserId, userId);
            return View("ObjectiveView", objective);
        }
    }
}
