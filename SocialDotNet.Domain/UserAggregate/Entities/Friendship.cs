using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Domain.UserAggregate.Entities
{
    public class Friendship : Entity<FriendshipId>
    {
        public UserId UserId { get; private set; }
        public UserId FriendId { get; private set; }    
        public DateTime CreatedAt { get; private set; }

        private Friendship(FriendshipId id, UserId userId, UserId friendId) : base(id)
        {
            UserId = userId;
            FriendId = friendId;
            CreatedAt = DateTime.UtcNow;
        }

        public static Friendship Create(UserId userId, UserId friendId)
        {
            return new Friendship(FriendshipId.CreateUnique(), userId, friendId);
        }

        private Friendship() { }
    }
}
