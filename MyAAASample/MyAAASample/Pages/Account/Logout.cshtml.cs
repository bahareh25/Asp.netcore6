using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAAASample.Models;

namespace MyAAASample.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<CostumIdentityUser> _signInManager;
        public LogoutModel(SignInManager<CostumIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGet()
        {
           await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
