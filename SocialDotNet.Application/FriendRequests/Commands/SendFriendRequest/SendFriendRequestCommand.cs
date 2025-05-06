using ErrorOr;
using MediatR;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Commands.CreateFriendRequest
{
    public record SendFriendRequestCommand(
        UserId UserId,
        string FriendName) : IRequest<ErrorOr<Unit>>;
}
