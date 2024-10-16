using Microsoft.AspNetCore.Mvc;

namespace MyViewComponentSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }
    }
}
