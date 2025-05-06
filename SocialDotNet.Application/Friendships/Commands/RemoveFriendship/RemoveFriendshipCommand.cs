using ErrorOr;
using MediatR;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Friendships.Commands.RemoveFriendship
{
    public record RemoveFriendshipCommand(
        UserId UserId,
        UserId FriendId) : IRequest<ErrorOr<FriendshipResult>>;
}
