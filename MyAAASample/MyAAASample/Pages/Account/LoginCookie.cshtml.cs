using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAAASample.Pages.Account
{
    public class LoginCookiesModel : PageModel
    {
        public string CookieValue { get; set; }
        public void OnGet()
        {
            if (Request.Cookies.ContainsKey(".ASPNetCore.Identity.Application"))
            {
                CookieValue = Request.Cookies[".ASPNetCore.Identity.Application"];
            }
            else { 
                CookieValue = "There is No cookies"; }
        }
    }
}
