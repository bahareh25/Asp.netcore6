using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SsoSample.MVC.Models;
using System.Diagnostics;

namespace SsoSample.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;    
        public HomeController(ILogger<HomeController> logger,IHttpClientFactory factory)
        {
            _httpClient=factory.CreateClient("W");
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var acessToken = await HttpContext.GetTokenAsync("access_token");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", acessToken);
            var resultString =await _httpClient.GetStringAsync("/WeatherForecast");
            var result=JsonConvert.DeserializeObject<List<WeatherForecast>>(resultString);
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public  IActionResult LogOut()
        {
            return SignOut("Cookies","oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}