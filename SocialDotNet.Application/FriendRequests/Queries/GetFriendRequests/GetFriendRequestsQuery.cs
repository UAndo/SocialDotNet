using ErrorOr;
using MediatR;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Queries.GetFriendRequests
{
    public record GetFriendRequestsQuery(
        UserId UserId): IRequest<ErrorOr<List<FriendRequestResult>>>;
}
