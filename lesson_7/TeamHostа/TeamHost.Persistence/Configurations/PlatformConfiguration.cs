using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.HasMany(x => x.Games)
            .WithMany(x => x.Platforms);

        builder.HasOne(p => p.Image)
            .WithOne(x => x.Platform)
            .HasForeignKey<Platform>(p => p.ImageId);

    }
}