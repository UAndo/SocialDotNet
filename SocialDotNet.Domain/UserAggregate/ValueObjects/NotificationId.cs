using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.UserAggregate.ValueObjects
{
    public class NotificationId : ValueObject
    {
        public Guid Value { get; private set; }

        private NotificationId(Guid value)
        {
            Value = value;
        }

        public static NotificationId CreateUnique()
        {
            return new NotificationId(Guid.NewGuid());
        }

        public static NotificationId Create(Guid value)
        {
            return new NotificationId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
