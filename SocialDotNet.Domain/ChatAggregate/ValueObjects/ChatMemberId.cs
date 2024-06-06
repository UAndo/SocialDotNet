using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.ChatAggregate.ValueObjects
{
    public class ChatMemberId : ValueObject
    {
        public Guid Value { get; private set; }

        private ChatMemberId(Guid value)
        {
            Value = value;
        }

        public static ChatMemberId CreateUnique()
        {
            return new ChatMemberId(Guid.NewGuid());
        }

        public static ChatMemberId Create(Guid value)
        {
            return new ChatMemberId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
