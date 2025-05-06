using ErrorOr;
using MediatR;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Friendships.Queries
{
    public record GetFriendsQuery(
        UserId UserId) : IRequest<ErrorOr<List<FriendRequest>>>;
}
