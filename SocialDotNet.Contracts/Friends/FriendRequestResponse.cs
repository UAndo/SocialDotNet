namespace SocialDotNet.Contracts.Friends
{
    public record FriendRequestResponse(
        Guid Id,
        string Avatar,
        string Username,
        string Status);
}
