using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialDotNet.Domain.ChatAggregate;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Configurations
{
    public class ChatConfigurations : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            ConfigureChatsTable(builder);
            ConfigureMessagesTable(builder);
            ConfigureChatMembersTable(builder);
        }

        public void ConfigureChatsTable(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chats");

            builder.Property(c => c.Name)
                .HasMaxLength(100);

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasConversion(
                    id => id.Value,
                    value => ChatId.Create(value));
        }

        public void ConfigureMessagesTable(EntityTypeBuilder<Chat> builder)
        {
            builder.OwnsMany(c => c.Messages, mb =>
            {
                mb.ToTable("Messages");

                mb.WithOwner().HasForeignKey("ChatId");

                mb.HasKey("Id");

                mb.Property(m => m.Id)
                    .HasColumnName("MessageId")
                    .HasConversion(
                        id => id.Value,
                        value => MessageId.Create(value));

                mb.Property(m => m.Content)
                    .IsRequired()
                    .HasMaxLength(1000);

                mb.Property(m => m.SenderId)
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Create(value))
                    .IsRequired();

                mb.Property(m => m.SentAt)
                    .IsRequired();
            });
        }

        public void ConfigureChatMembersTable(EntityTypeBuilder<Chat> builder)
        {
            builder.OwnsMany(c => c.ChatMembers, pb =>
            {
                pb.ToTable("ChatMembers");

                pb.WithOwner().HasForeignKey("ChatId");

                pb.HasKey("Id", "ChatId");

                pb.Property(p => p.Id)
                    .HasColumnName("ChatMemberId")
                    .HasConversion(
                        id => id.Value,
                        value => ChatMemberId.Create(value));

                pb.Property(p => p.UserId)
                    .IsRequired()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Create(value));

                pb.Property(p => p.JoinedAt)
                    .IsRequired();
            });
        }
    }
}
