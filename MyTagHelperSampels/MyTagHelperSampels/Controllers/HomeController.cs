using Microsoft.AspNetCore.Mvc;

namespace MyTagHelperSampels.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
