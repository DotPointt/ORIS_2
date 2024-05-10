using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chats>
{
    public void Configure(EntityTypeBuilder<Chats> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ChatImage)
            .WithOne(x => x.Chats)
            .HasForeignKey<StaticFile>(x => x.ChatId);
    }
}