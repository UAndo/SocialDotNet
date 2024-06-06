using MediatR;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Friendships.Commands.RemoveFriendship
{
    public record RemoveFriendshipCommand(
        FriendshipId FriendshipId) : IRequest;
}
