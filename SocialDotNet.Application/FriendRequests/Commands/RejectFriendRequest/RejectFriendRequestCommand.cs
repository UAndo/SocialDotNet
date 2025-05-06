using ErrorOr;
using MediatR;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Commands.RejectFriendRequest
{
    public record RejectFriendRequestCommand(
        UserId UserId,
        UserId FriendRequestId) : IRequest<ErrorOr<Unit>>;
}
