
using myCourseStore.Model.Teachers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace myCourseStore.DAL.Teachers;

public class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(c => c.FirstName).HasMaxLength(200);
        builder.Property(c=>c.LastName).HasMaxLength(300);
    
    }
}