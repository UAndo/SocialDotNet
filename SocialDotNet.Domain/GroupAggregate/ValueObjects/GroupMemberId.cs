using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.GroupAggregate.ValueObjects
{
    public sealed class GroupMemberId : ValueObject
    {
        public Guid Value { get; }

        private GroupMemberId(Guid value)
        {
            Value = value; 
        }

        public static GroupMemberId CreateUnique()
        {
            return new GroupMemberId(Guid.NewGuid());
        }

        public static GroupMemberId Create(Guid value)
        {
            return new GroupMemberId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
