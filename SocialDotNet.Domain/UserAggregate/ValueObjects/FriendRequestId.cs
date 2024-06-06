using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.UserAggregate.ValueObjects
{
    public class FriendRequestId : ValueObject
    {
        public Guid Value { get; private set; }

        private FriendRequestId(Guid value)
        {
            Value = value;
        }

        public static FriendRequestId CreateUnique()
        {
            return new FriendRequestId(Guid.NewGuid());
        }

        public static FriendRequestId Create(Guid value)
        {
            return new FriendRequestId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
