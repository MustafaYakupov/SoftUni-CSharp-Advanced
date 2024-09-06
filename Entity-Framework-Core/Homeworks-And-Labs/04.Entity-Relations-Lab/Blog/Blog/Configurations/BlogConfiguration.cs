
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDemo.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder
            .Property(b => b.Created)
            .ValueGeneratedOnAdd();

        builder
            .Property(b => b.LastUpdated)
            .ValueGeneratedOnUpdate();
    }
}
