using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.GroupAggregate.ValueObjects;

namespace SocialDotNet.Domain.GroupAggregate.Entities
{
    public sealed class GroupPost : Entity<GroupPostId>
    {
        public GroupId GroupId { get; }
        public GroupMemberId MemberId { get; }
        public int Likes { get; } = 0;
        public int Replies { get; } = 0; 

        public GroupPost(
            GroupPostId id,
            GroupId groupId,
            GroupMemberId memberId) : base(id)
        {
            GroupId = groupId;
            MemberId = memberId;
        }

        private GroupPost()
        {
        }

        public static GroupPost Create(
            GroupId groupId,
            GroupMemberId memberId)
        { 
            return new GroupPost(GroupPostId.CreateUnique(),
                groupId,
                memberId);
        }
    }
}
