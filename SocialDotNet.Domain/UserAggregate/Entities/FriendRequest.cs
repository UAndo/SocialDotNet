using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.Enums;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Domain.UserAggregate.Entities
{
    public class FriendRequest : Entity<FriendRequestId>
    {
        public UserId SenderId { get; private set; }
        public UserId ReceiverId { get; private set; }
        public FriendRequestStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private FriendRequest(FriendRequestId id, UserId senderId, UserId receiverId, FriendRequestStatus status, DateTime createdAt)
            : base(id)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Status = status;
            CreatedAt = createdAt;
        }

        public static FriendRequest Create(UserId senderId, UserId receiverId)  
        {
            return new FriendRequest(FriendRequestId.CreateUnique(), senderId, receiverId, FriendRequestStatus.Pending, DateTime.UtcNow);
        }

        public void Accept()
        {
            Status = FriendRequestStatus.Accepted;
        }

        public void Reject()
        {
            Status = FriendRequestStatus.Rejected;
        }

        private FriendRequest() { }
    }
}
