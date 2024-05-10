using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description);

        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.HasMany(x => x.Games)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);

    }
}