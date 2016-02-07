using Microsoft.AspNet.Mvc;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.Components
{
    public class ContactViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var contact = DbContext.ContactDetail.Find(
                       x => x.UserId, userId);

            if (contact != null) return View("ContactView", contact);

            contact = new ContactDetail
            {
                FirstName = User.GetName(),
            };
            return View("ContactView", contact);
            
        }

    }
}
