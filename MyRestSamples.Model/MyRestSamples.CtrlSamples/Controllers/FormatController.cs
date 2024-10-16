using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MyRestSamples.CtrlSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
     [HttpGet("Str")]
        public string GetStr()
        {
            return "Hello World";
        }
        [HttpGet("Int")]
        public int GetInt() => 1;
        [HttpGet("Obj")]
        public Object GetObject() => new
        {
            FirstName = "bahar",
            LastName = "Broumand"
        };
    }
}
