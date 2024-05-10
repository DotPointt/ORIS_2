using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class StaticFileConfiguration : IEntityTypeConfiguration<StaticFile>
{
    public void Configure(EntityTypeBuilder<StaticFile> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedBy)
            .HasDefaultValue(1);
        builder.Property(x => x.UpdatedDate);
        builder.Property(x => x.UpdatedBy);
        builder.Property(x => x.CreatedDate)     
            .HasDefaultValue(DateTime.Now.ToUniversalTime());
        
        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.Property(p => p.Path)
            .IsRequired();

        builder.Property(p => p.Size)
            .IsRequired();
    }
}