using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.GroupAggregate.Enums;
using SocialDotNet.Domain.GroupAggregate.ValueObjects;

namespace SocialDotNet.Domain.GroupAggregate.Entities
{
    public sealed class GroupMember : Entity<GroupMemberId>
    {

        public string Name { get; private set; }
        public string Role { get; private set; }
        public GroupMemberStatus GroupMemberStatus { get; private set; }

        public GroupMember(
            GroupMemberId groupMemberId,
            string name,
            string role) : base(groupMemberId)
        {
            Name = name;
            Role = role;
            GroupMemberStatus = GroupMemberStatus.Active;
        }

        private GroupMember()
        {
        }

        public static GroupMember Create(
            string name,
            string role)
        {
            return new(GroupMemberId.CreateUnique(),
                name,
                role);
        }
    }
}
