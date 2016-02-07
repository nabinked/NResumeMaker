using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Services.ToastNotification;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeMaker.Controllers
{
    public class SearchController : ResumeMakerBaseController
    {
        // GET: /<controller>/
        public IActionResult Index(string searchString)
        {
            ViewData["SearchName"] = searchString;
            return View();
        }

        public SearchController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
