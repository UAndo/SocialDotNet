using SocialDotNet.Domain.UserAggregate;

namespace SocialDotNet.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token,
        string RefreshToken);
}
