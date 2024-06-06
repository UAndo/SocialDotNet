using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.ChatAggregate.ValueObjects
{
    public sealed class ChatId : ValueObject
    {
        public Guid Value { get; private set; }

        private ChatId(Guid value)
        {
            Value = value;
        }

        public static ChatId CreateUnique()
        {
            return new ChatId(Guid.NewGuid());
        }

        public static ChatId Create(Guid value)
        {
            return new ChatId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
