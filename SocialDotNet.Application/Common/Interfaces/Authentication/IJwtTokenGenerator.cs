using SocialDotNet.Domain.UserAggregate;
using SocialDotNet.Domain.UserAggregate.Entities;

namespace SocialDotNet.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
        RefreshToken GenerateRefreshToken();
    }
}