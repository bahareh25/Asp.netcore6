using Microsoft.EntityFrameworkCore;

namespace MyAsp6Store.ShopUI.Models
{
    public class StorDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Category> categories { get; set; }
        public StorDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Mobile",
                },
                new Category
                {
                    Id = 2,
                    Name = "LapTop",
                },
                new Category
                {
                    Id = 3,
                    Name = "PC",
                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Apple Iphone13",
                    Description = "this is Apple Iphone 13",
                    Price = 30_000_000
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Samsung Galaxy",
                    Description = "This is Samsung Galaxy",
                    Price = 25_000_000
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Xiamoi Poco",
                    Description = "this is Xiamoi Poco",
                    Price = 0
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "ZenBook Flip",
                    Description = "This is Asus Laptop",
                    Price = 40_000_000
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "VivoBook",
                    Description = "This is Asus Laptop",
                    Price = 50_000_000
                },
                 new Product
                 {
                     Id = 6,
                     CategoryId = 2,
                     Name = "ASUS Zenbook 14X OLED",
                     Description = "This is Asus Laptop",
                     Price = 50_000_000
                 },
                  new Product
                  {
                      Id = 7,
                      CategoryId = 2,
                      Name = "ProArt Studiobook 16",
                      Description = "This is Asus Laptop",
                      Price = 50_000_000
                  },
                   new Product
                   {
                       Id = 8,
                       CategoryId = 3,
                       Name = "ASUS ProArt Display PA278CV",
                       Description = "This is Asus Pc",
                       Price = 50_000_000
                   },
                    new Product
                    {
                        Id = 9,
                        CategoryId =3,
                        Name = "Sleek and ultra-portable with a Zen-inspired design",
                        Description = "With a slim 8.5 mm (0.3-inch) profile and tipping the scales at just 800g (1.76 pounds), the MB169B+ is the world’s slimmest and lightest companion display, ideal for a simple on-the-go dual-monitor setup and mobile presentations.",
                        Price = 190_000_000
                    },
                     new Product
                     {
                         Id = 10,
                         CategoryId = 3,
                         Name = "Asus Mini PC",
                         Description = "This is Asus PC",
                         Price = 50_000_000
                     }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
