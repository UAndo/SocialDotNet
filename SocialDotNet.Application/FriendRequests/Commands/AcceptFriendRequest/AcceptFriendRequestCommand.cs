using ErrorOr;
using MediatR;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Commands.AcceptFriendRequest
{
    public record AcceptFriendRequestCommand(
        UserId UserId,
        UserId FriendId) : IRequest<ErrorOr<Unit>>;
}
