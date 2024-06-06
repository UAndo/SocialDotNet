using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.GroupAggregate.Entities;
using SocialDotNet.Domain.GroupAggregate.ValueObjects;

namespace SocialDotNet.Domain.GroupAggregate
{
    public sealed class Group : AggregateRoot<GroupId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        private readonly List<GroupMember> _members = new();
        private readonly List<GroupPost> _posts = new();
        public IReadOnlyList<GroupPost> Posts => _posts.ToList();
        public IReadOnlyList<GroupMember> Members => _members.ToList();

        private Group(
            GroupId id,
            string name,
            string description,
            string imageUrl,
            List<GroupMember> members,
            List<GroupPost> posts) : base(id)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            _members = members;
            _posts = posts;
        }

        private Group()
        {
        }
    }
}
