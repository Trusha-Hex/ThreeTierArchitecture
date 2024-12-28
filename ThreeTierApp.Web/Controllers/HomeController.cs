using Microsoft.AspNetCore.Mvc;

namespace ThreeTierApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // This will render Views/Home/index.cshtml
        }
    }
}
