using Microsoft.AspNetCore.Mvc;

namespace MyAAASample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
