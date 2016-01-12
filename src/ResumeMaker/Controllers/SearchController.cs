using Microsoft.AspNet.Mvc;

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
    }
}
