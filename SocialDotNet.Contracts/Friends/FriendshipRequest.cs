namespace SocialDotNet.Contracts.Friends
{
    public record FriendshipRequest(
        Guid UserId,
        Guid FriendId);
}
