using Microsoft.AspNetCore.Mvc;
using RealTimeSamples.SSE.Models;
using System.Diagnostics;
using RealTimeSamples.SSE.Extensions;

namespace RealTimeSamples.SSE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/sse")]
        public async Task SSE()
        {
            await HttpContext.ssEInitAsync();
            int counter = 0;
            do
            {
                await HttpContext.ssESendAsync($"This is message number:{counter}");
                Thread.Sleep(1000);
                counter++;
            }while(counter < 10);
        }
    }
}