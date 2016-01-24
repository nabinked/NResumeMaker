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
        public ResumeMakerBaseController()
        {

        }

        public DbContext DbContext => new DbContext();

        public long UserId => User.GetId();

        [FromServices]
        public IOptions<Appsettings> AppSettings { get; set; }

        [FromServices]
        public IToastNotification ToastNotification { get; set; }

        [FromServices]
        public IConnectionFactory ConnectionFactory { get; set; }

        public string ConnectionString => ConnectionFactory.ConnectionString;

        public IActionResult RedirectToHomeIfReturnUrlEmpty(string returnUrl)
        {
            return string.IsNullOrWhiteSpace(returnUrl) ? (IActionResult)RedirectToAction("Index", "Home") : Redirect(returnUrl);
        }

        public override RedirectResult Redirect(string url)
        {
            return base.Redirect(string.IsNullOrEmpty(url) ? Url.Action("Index", "Home") : url);
        }

        public void ShowToastNotification(string message, ToastEnums.ToastType type, string title = "")
        {
            ToastNotification.AddToastMessage(title, message, type);
        }
    }
}
