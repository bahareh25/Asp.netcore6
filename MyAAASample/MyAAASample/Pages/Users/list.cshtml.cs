using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAAASample.Models;

namespace MyAAASample.Pages.Users
{
    public class listModel : PageModel
    {
        private readonly UserManager<CostumIdentityUser> _userManager;
        public IEnumerable<CostumIdentityUser> Users { get; set; } = Enumerable.Empty<CostumIdentityUser>();
        public listModel(UserManager<CostumIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
            Users=_userManager.Users.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
                var user = await _userManager.FindByIdAsync(id);
             if (user!=null)
            { await _userManager.DeleteAsync(user); 
            }
            return RedirectToPage();
        }
    }
}
