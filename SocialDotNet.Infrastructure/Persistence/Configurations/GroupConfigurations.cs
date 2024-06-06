using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialDotNet.Domain.GroupAggregate;
using SocialDotNet.Domain.GroupAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Configurations
{
    public class GroupConfigurations : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            ConfigureGroupsTable(builder);
            ConfigureGroupMembersTable(builder);
            ConfigureGroupPostsTable(builder);
        }


        private void ConfigureGroupsTable(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value, 
                    value => GroupId.Create(value));

            builder.Property(g => g.Name)
                .HasMaxLength(100);

            builder.Property(g => g.Description)
                .HasMaxLength(100);
        }

        private void ConfigureGroupMembersTable(EntityTypeBuilder<Group> builder)
        {
            builder.OwnsMany(g => g.Members, mb =>
            {
                mb.ToTable("GroupMembers");

                mb.WithOwner().HasForeignKey("GroupId");

                mb.HasKey("Id", "GroupId");

                mb.Property(g => g.Id)
                    .HasColumnName("GroupMemberId")
                    .HasConversion(
                        id => id.Value,
                        value => GroupMemberId.Create(value));

                mb.Property(g => g.Role)
                    .HasMaxLength(100);
            });
        }

        private void ConfigureGroupPostsTable(EntityTypeBuilder<Group> builder)
        {
            builder.OwnsMany(g => g.Posts, pb =>
            {
                pb.ToTable("GroupPosts");

                pb.WithOwner().HasForeignKey("GroupId");

                pb.HasKey("Id", "GroupId");

                pb.Property(g => g.Id)
                    .HasColumnName("GroupPostId")
                    .HasConversion(
                        id => id.Value,
                        value => GroupPostId.Create(value));
            });
        }
    }
}
