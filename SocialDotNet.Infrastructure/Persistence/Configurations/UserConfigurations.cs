using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialDotNet.Domain.UserAggregate;
using SocialDotNet.Domain.UserAggregate.Enums;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUsersTable(builder);
            ConfigureRefreshTokensTable(builder);
            ConfigureFriendRequestTable(builder);
            ConfigureFriendshipsTable(builder);
        }


        private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Bio)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(u => u.PasswordResetCode)
                .IsRequired(false)
                .HasMaxLength(100);
        }

        private void ConfigureRefreshTokensTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.RefreshTokens, rb =>
            {
                rb.ToTable("RefreshTokens");

                rb.WithOwner().HasForeignKey("UserId");

                rb.HasKey("Id", "UserId");

                rb.Property(r => r.Id)
                    .HasColumnName("RefreshTokenId")
                    .HasConversion(
                        id => id.Value,
                        value => RefreshTokenId.Create(value));

                rb.Property(r => r.ReasonRevoked)
                    .HasMaxLength(100);
            });
        }
        private void ConfigureFriendRequestTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.FriendRequests, fb =>
            {
                fb.ToTable("FriendRequests");

                fb.HasKey("Id", "UserId");

                fb.Property(fr => fr.Id)
                    .HasColumnName("FriendRequestId")
                    .HasConversion(
                        id => id.Value,
                        value => FriendRequestId.Create(value));

                fb.Property(fr => fr.SenderId)
                    .IsRequired()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Create(value));

                fb.Property(fr => fr.ReceiverId)
                    .IsRequired()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Create(value));

                fb.Property(fr => fr.Status)
                    .IsRequired()
                    .HasConversion(
                        status => status.ToString(),
                        value => Enum.Parse<FriendRequestStatus>(value));

                fb.Property(fr => fr.CreatedAt)
                    .IsRequired();
            });
        }

        private void ConfigureFriendshipsTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.Friendships, fb =>
            {
                fb.ToTable("Friendships");

                fb.WithOwner().HasForeignKey("UserId");

                fb.HasKey("Id", "UserId");

                fb.Property(f => f.Id)
                    .HasColumnName("FriendshipId")
                    .HasConversion(
                        id => id.Value,
                        value => FriendshipId.Create(value));

                fb.Property(f => f.FriendId)
                    .IsRequired()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Create(value));
            });
        }
    }
}
