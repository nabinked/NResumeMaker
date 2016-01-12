using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Common.Extensions;
using ResumeMaker.Data;

namespace ResumeMaker.Controllers
{
    public class ResumeMakerBaseController : Controller
    {
        public ResumeMakerBaseController()
        {

        }

        public DbContext DbContext { get { return new DbContext(); } }

        public long UserId => User.GetId();

        [FromServices]
        public IOptions<Appsettings> AppSettings { get; set; }

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
    }
}
