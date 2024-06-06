using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Domain.UserAggregate.Entities
{
    public class RefreshToken : Entity<RefreshTokenId>
    {
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime? Revoked { get; private set; }
        public string? ReplacedByToken { get; private set; }
        public string? ReasonRevoked { get; private set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;

        private RefreshToken(
            RefreshTokenId id,
            string token,
            DateTime expires,
            DateTime created) : base(id)
        {
            Token = token;
            Expires = expires;
            Created = created;
        }

        private RefreshToken() 
        {
        }

        public static RefreshToken Create(
            string token,
            DateTime expires,
            DateTime created
            )
        {
            var refreshToken = new RefreshToken(RefreshTokenId.CreateUnique(), token, expires, created);

            return refreshToken;
        }

        public static RefreshToken SetRevoked(
            RefreshToken refreshToken,
            DateTime revoked,
            string replacedByToken,
            string reasonRevoked
            )
        {
            refreshToken.Revoked = revoked;
            refreshToken.ReplacedByToken = refreshToken.ReplacedByToken;
            refreshToken.ReasonRevoked = reasonRevoked;

            return refreshToken;
        }
    }
}
