using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data.Models.Core;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Controllers
{
    public class PersonalDetailController :ResumeMakerBaseController
    {
        [HttpPost]
        public IActionResult AddUpdate(PersonalDetail personalDetail, string returnUrl)
        {
            if (personalDetail.IsNew)
            {
                personalDetail.UserId = User.GetId();
                if (DbContext.PersonalDetail.Create(personalDetail) > 0)
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
                if (DbContext.PersonalDetail.Update(personalDetail))
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

        public PersonalDetailController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
