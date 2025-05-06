namespace SocialDotNet.Application.Authentication.Common
{
    public record RevokedTokenResult(
        string Token,
        DateTime RevokedAt,
        string Reason);
}
