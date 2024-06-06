using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.ChatAggregate.ValueObjects
{
    public sealed class MessageId : ValueObject
    {
        public Guid Value { get; private set; }

        private MessageId(Guid value)
        {
            Value = value;
        }

        public static MessageId CreateUnique()
        {
            return new MessageId(Guid.NewGuid());
        }

        public static MessageId Create(Guid value)
        {
            return new MessageId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
