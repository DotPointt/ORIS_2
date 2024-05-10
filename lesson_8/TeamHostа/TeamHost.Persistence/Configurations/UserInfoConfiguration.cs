using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.FirstName)
            .IsRequired();

        builder.Property(p => p.LastName)
            .IsRequired();

        builder.Property(p => p.Patronimic);
        
        builder.Property(p => p.Birthday);

        builder.Property(p => p.About);

        builder.Property(x => x.NickName)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(x => x.Country)
            .WithMany(y => y.Users)
            .HasForeignKey(x => x.CountryId);

        builder.HasOne(x => x.User)
            .WithOne(y => y.UserInfo)
            .HasForeignKey<UserInfo>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id);
    }
}