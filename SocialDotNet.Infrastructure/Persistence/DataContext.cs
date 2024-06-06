using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialDotNet.Domain.UserAggregate;
using SocialDotNet.Domain.GroupAggregate;
using SocialDotNet.Domain.GroupAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate;
using SocialDotNet.Domain.ChatAggregate.Entities;

namespace SocialDotNet.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupPost> GroupPosts { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.IsPrimaryKey())
                .ToList()
                .ForEach(p => p.ValueGenerated = ValueGenerated.Never);
            base.OnModelCreating(modelBuilder);
        }
    }
}
