using SocialDotNet.Domain.UserAggregate;
using SocialDotNet.Domain.UserAggregate.Entities;

namespace SocialDotNet.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
        RefreshToken GenerateRefreshToken();
        RefreshToken RotateRefreshToken(RefreshToken refreshToken);
        void RemoveOldRefreshTokens(User user);
        void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string reason);
        void RevokeRefreshToken(RefreshToken token, string reason = null, string replacedByToken = null);
    }
}