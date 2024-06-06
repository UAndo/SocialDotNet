using SocialDotNet.Domain.Common.Models;

namespace SocialDotNet.Domain.UserAggregate.ValueObjects
{
    public class RefreshTokenId : ValueObject
    {
        public Guid Value { get; }

        private RefreshTokenId(Guid value)
        {
            Value = value;
        }

        public static RefreshTokenId CreateUnique()
        {
            return new RefreshTokenId(Guid.NewGuid());
        }

        public static RefreshTokenId Create(Guid value)
        {
            return new RefreshTokenId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
