using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .IsRequired();
        
        builder.Property(x => x.Description);
        
        builder.Property(x => x.Rating)
            .HasDefaultValue(0);

        builder.Property(x => x.ShortDescription);

        builder.Property(x => x.MainFileId);
        
        builder.Property(x => x.ReleaseDate);

        builder.Property(x => x.CreatedBy)
            .HasDefaultValue(1);
        builder.Property(x => x.UpdatedBy);
        builder.Property(x => x.UpdatedDate);
        builder.Property(x => x.CreatedDate)
            .HasDefaultValue(DateTime.Now.ToUniversalTime());
        
        builder.HasMany(x => x.Images)
            .WithOne(x => x.Game)
            .HasForeignKey(x => x.GameId);

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Games)
            .HasForeignKey(x => x.CompanyId);

        builder.HasMany(x => x.Category)
            .WithMany(x => x.Games);
    }
}