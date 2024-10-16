using Microsoft.AspNetCore.Mvc;

namespace RealTimeSamples.Ajax.Controllers
{
    public class DataController : Controller
    {
        public class Tweet
        {
            public string senderName{ get; set; }
            public string message{ get; set; }
        }
        public IActionResult Index()
        {
            return Ok(new List<Tweet>
            {
                new Tweet { senderName="Bahareh",
                message="FirstTweet of Bahareh"},
                new Tweet { senderName="Mohammad",
                message="FirstTweet of Mohammad"},
                new Tweet { senderName="Alireza",
                message="FirstTweet of Alireza"},
            });
        }
    }
}
