using MediatR;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Commands.CreateFriendRequest
{
    public record CreateFriendRequestCommand(
        UserId SenderId,
        UserId ReceiverId) : IRequest;
}
