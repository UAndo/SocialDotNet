using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Contracts.Friends
{
    public record CreateFriendRequest(
        Guid UserId,
        string FriendName);
}
