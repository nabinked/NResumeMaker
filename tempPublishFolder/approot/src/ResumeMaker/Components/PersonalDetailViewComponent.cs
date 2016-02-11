using Microsoft.AspNet.Mvc;

namespace ResumeMaker.Components
{
    public class PersonalDetailViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var personalDetail =DbContext.PersonalDetail.Find(
                    x => x.UserId, userId);
            return View("PersonalDetailView", personalDetail);
        }

    }
}
