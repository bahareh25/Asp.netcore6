using Microsoft.EntityFrameworkCore;

namespace MyValidationSample.Models
{
    public class ValidationDbContex : DbContext
    {
        public DbSet<Person> People{ get; set; }
        public ValidationDbContex(DbContextOptions options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
           configurationBuilder.Properties<string>().HaveMaxLength(20);
        }
    }
}
