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
    public class ContactDetailsController : ResumeMakerBaseController
    {
        public ContactDetailsController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }

        [HttpPost]
        public IActionResult AddUpdateContact(ContactDetail contactDetails, string returnUrl)
        {
            if (contactDetails.IsNew)
            {
                contactDetails.UserId = User.GetId();
                if (DbContext.ContactDetail.Create(contactDetails) > 0)
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
                if (DbContext.ContactDetail.Update(contactDetails))
                {
                    ShowUpdateSuccessfullyToast();
                }
                else
                {
                    ShowTaskFailedToast();
                }
                ;
            }
            return Redirect(returnUrl);
        }

    }
}
