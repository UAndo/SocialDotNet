using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.UserAggregate.ValueObjects
{
    public class FriendshipId : ValueObject
    {
        public Guid Value { get; private set; }

        private FriendshipId(Guid value)
        {
            Value = value;
        }

        public static FriendshipId CreateUnique()
        {
            return new FriendshipId(Guid.NewGuid());
        }

        public static FriendshipId Create(Guid value)
        {
            return new FriendshipId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
