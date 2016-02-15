using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;
using ResumeMaker.Services.ToastNotification;
using ResumeMaker.ViewModels.Home;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeMaker.Controllers
{
    public class HomeController : ResumeMakerBaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.ResumeDisplayTiles = GetResumeDisplayTiles();
            return View();
        }

        public HomeController(IToastNotification toastNotification, IOptions<Appsettings> appOptions) : base(toastNotification, appOptions)
        {
        }
    }
}
