using ErrorOr;
using MediatR;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Friendships.Commands.CreateFriendship
{
    public record CreateFriendshipCommand(
        UserId UserId,
        UserId FriendId) : IRequest<ErrorOr<FriendshipResult>>;
}
