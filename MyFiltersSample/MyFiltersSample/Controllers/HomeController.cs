using Microsoft.AspNetCore.Mvc;
using MyFiltersSample.Filters;

namespace MyFiltersSample.Controllers

{   //[RequireHttps]
    //[MyHttps]
    [FilterOrder("Contoler01")]
    [FilterOrder("Contoler02")]
    public class HomeController : Controller
    {
        //[ActionTimer]
        //[ResultrTimer]
        //[MyGuid("FirstGuid")]
        //[MyGuid("SeccondGuid")]
        //[TypeFilter(typeof(DiFillterAttribute))]
        //[ServiceFilter(typeof(MyGuidAttribute))]
        //[ServiceFilter(typeof(MyGuidAttribute))]
        [FilterOrder("Action01",Order =10)]
        [FilterOrder("Action02",Order =5)]
        [FilterOrder("Action03",Order =11)]
        [FilterOrder("Action04",Order =20)]
        [FilterOrder("Action05", Order = 0)]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [MyCache]
        public IActionResult CacheSample()
        {
            return View(DateTime.Now);
        }
    }
}
