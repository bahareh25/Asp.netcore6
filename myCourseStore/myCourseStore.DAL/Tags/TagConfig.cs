
using myCourseStore.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace myCourseStore.DAL.Tags;

public class TagConfig : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(c => c.TagName).HasMaxLength(50);
        builder.Property(c=>c.Id).IsRequired();
    }
}