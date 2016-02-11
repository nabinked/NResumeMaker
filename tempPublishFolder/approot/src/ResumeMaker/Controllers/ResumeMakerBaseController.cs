using DbPortal;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Controllers
{
    public class ResumeMakerBaseController : Controller
    {
        public ResumeMakerBaseController(IToastNotification toastNotification, IOptions<Appsettings> appOptions)
        {
            ToastNotification = toastNotification;
            AppSettings = appOptions.Value;
        }

        public DbContext DbContext => new DbContext();

        public long UserId => User.GetId();

        public Appsettings AppSettings { get; set; }

        private IToastNotification ToastNotification { get; set; }


        public override RedirectResult Redirect(string url)
        {
            return base.Redirect(string.IsNullOrEmpty(url) ? Url.Action("Index", "Home") : url);
        }

        public RedirectResult RedirectToHome(string redirectUrl = "")
        {
            return base.Redirect(string.IsNullOrEmpty(redirectUrl) ? Url.Action("Index", "Home") : redirectUrl);
        }

        public void ShowToastNotification(string message, ToastEnums.ToastType type, string title = "")
        {
            ToastNotification.AddToastMessage(title, message, type);
        }
        public void ShowDeletedSuccessfullyToast()
        {
            ToastNotification.AddToastMessage("Task Successfull", "Deleted Succesfully", ToastEnums.ToastType.Success);
        }

        public void ShowSavedSuccessfullyToast()
        {
            ToastNotification.AddToastMessage("Task Successfull", "Record saved Succesfully", ToastEnums.ToastType.Success);
        }

        public void ShowUpdateSuccessfullyToast()
        {
            ToastNotification.AddToastMessage("Task Successfull", "Record updated Succesfully", ToastEnums.ToastType.Success);
        }

        public void ShowTaskFailedToast(string errorMessage = "Unknow error uccurred ! Please contact support service.")
        {
            ToastNotification.AddToastMessage("Task Failed", errorMessage, ToastEnums.ToastType.Error);
        }

        private string GetCurrentRequestUrl()
        {
            return Request.Scheme + "://" + Request.Host + Request.Path;
        }

    }
}
