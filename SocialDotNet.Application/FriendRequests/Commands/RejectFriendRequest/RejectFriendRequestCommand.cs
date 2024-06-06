using MediatR;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Commands.RejectFriendRequest
{
    public record RejectFriendRequestCommand(
        FriendRequestId FriendRequestId) : IRequest;
}
