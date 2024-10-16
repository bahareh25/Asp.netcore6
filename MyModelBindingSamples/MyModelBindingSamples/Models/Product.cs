using Microsoft.EntityFrameworkCore;

namespace MyModelBindingSamples.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyModelBindingContext:DbContext
    {
        public MyModelBindingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
