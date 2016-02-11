using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Controllers
{
    public class SummaryController:ResumeMakerBaseController
    {
        [HttpPost]
        public IActionResult SaveUpdateSummary(Summary summary, string returnUrl)
        {
            if (summary.IsNew)
            {
                summary.UserId = User.GetId();
                if (DbContext.Summary.Create(summary) > 0)
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
                if (DbContext.Summary.Update(summary))
                {
                    ShowUpdateSuccessfullyToast();
                }
                else
                {
                    ShowTaskFailedToast();
                };
            }
            return Redirect(returnUrl);
        }

        public SummaryController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
