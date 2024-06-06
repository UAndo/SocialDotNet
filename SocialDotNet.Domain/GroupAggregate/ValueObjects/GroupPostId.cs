using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.GroupAggregate.ValueObjects
{
    public sealed class GroupPostId : ValueObject
    {
        public Guid Value { get; }

        private GroupPostId(Guid value)
        {
            Value = value;
        }

        public static GroupPostId CreateUnique()
        {
            return new GroupPostId(Guid.NewGuid());
        }

        public static GroupPostId Create(Guid value)
        {
            return new GroupPostId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
