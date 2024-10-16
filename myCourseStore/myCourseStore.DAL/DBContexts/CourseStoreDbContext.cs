using myCourseStore.Model.Courses.Entities;
using myCourseStore.Model.Orders.Entities;
using myCourseStore.Model.Tags.Entities;
using myCourseStore.Model.Teachers.Entities;
using Microsoft.EntityFrameworkCore;

namespace myCourseStore.DAL.DBContexts
{
    public class CourseStoreDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public CourseStoreDbContext(DbContextOptions<CourseStoreDbContext> options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("CreateDate").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate").HasMaxLength(50);
            }

        }
    }
}
