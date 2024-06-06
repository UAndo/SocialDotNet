using MediatR;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Commands.AcceptFriendRequest
{
    public record AcceptFriendRequestCommand(
        FriendRequestId FriendRequestId) : IRequest;
}
