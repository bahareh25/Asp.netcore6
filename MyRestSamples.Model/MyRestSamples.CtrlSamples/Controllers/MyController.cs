using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyRestSamples.CtrlSamples.Controllers
{
    [Route("api/[controller]")]

    public class MyController : ControllerBase
    {
        [HttpGet("GetName1")]
        public string GetName()
        {
            return "My Name is Bahareh Broumand";
        }
        [HttpGet("GetName2/{id}")]
        public string GetName2(int id)
        {
            return $"My Name is Bahareh Broumand 2-{id}";
        }
    }
}
