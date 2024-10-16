using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyAAASample.Models;

    public class MyAAADBContext:IdentityDbContext<CostumIdentityUser>
    {
        public MyAAADBContext(DbContextOptions options) : base(options)
        {

        }
    }

public class CostumIdentityUser : IdentityUser
{
    public string Name { get; set; }
    public string Family { get; set; }
}