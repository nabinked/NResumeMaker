using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Controllers
{
    public class ObjectiveController : ResumeMakerBaseController
    {
        [HttpPost]
        public IActionResult AddUpdateObjective(Objective objective, string returnUrl)
        {
            if (objective.IsNew)
            {
                objective.UserId = User.GetId();
                if (DbContext.Objective.Create(objective) > 0)
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
                if (DbContext.Objective.Update(objective))
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


        public ObjectiveController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
