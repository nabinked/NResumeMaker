using Microsoft.AspNet.Mvc;

namespace ResumeMaker.Components
{
    public class ContactViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var contact =DbContext.ContactDetail.Find(
                    x => x.UserId, userId);
            return View("ContactView", contact);
        }

    }
}
