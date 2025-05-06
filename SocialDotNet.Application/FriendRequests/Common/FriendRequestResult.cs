namespace SocialDotNet.Application.FriendRequests.Common
{
    public record FriendRequestResult(
        Guid Id,
        string Avatar,
        string Username,
        string Status);
}
