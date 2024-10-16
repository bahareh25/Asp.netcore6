using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAAASample.Models;

namespace MyAAASample.Pages.Users
{
    public class ManageRoleModel : PageModel
    {
        private readonly UserManager<CostumIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public List<string> Roles { get; set; }
        [BindProperty]
        public string Id { get; set; }
        public CostumIdentityUser CurrentUser { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public List<string> UserRoles { get; set; }
        public ManageRoleModel(UserManager<CostumIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task OnGet(string id)
        {
            CurrentUser = await _userManager.FindByIdAsync(id);
            UserRoles = (await _userManager.GetRolesAsync(CurrentUser)).ToList();
            AllRoles = _roleManager.Roles.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CurrentUser = await _userManager.FindByIdAsync(Id);
           
            AllRoles = _roleManager.Roles.ToList();
            foreach (var item in AllRoles)
            {
                if (Roles.Contains(item.Name))
                {
                    if (!(await _userManager.IsInRoleAsync(CurrentUser, item.Name)))
                    {
                        await _userManager.AddToRoleAsync(CurrentUser, item.Name);
                    }
                }
                else
                {
                    if ((await _userManager.IsInRoleAsync(CurrentUser, item.Name)))
                    {
                        await _userManager.RemoveFromRoleAsync(CurrentUser, item.Name);
                    }
                }
            }
           return RedirectToPage("List");
        }
    }
}
