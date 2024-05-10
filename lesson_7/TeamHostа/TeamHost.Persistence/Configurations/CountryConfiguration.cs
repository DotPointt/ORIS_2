using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Aplha2)
            .HasMaxLength(2);
        
        builder.Property(x => x.Aplha3)
            .HasMaxLength(3);
        
        builder.Property(x => x.Code);

        builder.Property(x => x.Fullname);
        
        builder.Property(x => x.Name)
            .IsRequired();
        
    }
}