using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(p => p.UpdatedDate);
        builder.Property(p => p.CreatedDate)
            .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(p => p.UpdatedBy);
        builder.Property(p => p.CreatedBy)
            .HasDefaultValue(1);

        builder.HasMany(x => x.Games)
            .WithMany(x => x.Category);
    }
}