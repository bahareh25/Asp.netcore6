using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFiltersSample.Filters;

namespace MyFiltersSample.Pages
{
     [MyHttps]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
