using ErrorOr;
using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.Entities;

namespace SocialDotNet.Application.Friendships.Commands.CreateFriendship
{
    public class CreateFriendshipCommandHandler : IRequestHandler<CreateFriendshipCommand, ErrorOr<FriendshipResult>>
    {
        private readonly IFriendshipRepository _friendshipRepository;

        public CreateFriendshipCommandHandler(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public async Task<ErrorOr<FriendshipResult>> Handle(CreateFriendshipCommand request, CancellationToken cancellationToken)
        {
            var friendship = Friendship.Create(request.UserId, request.FriendId);
            await _friendshipRepository.AddAsync(friendship);
            return new FriendshipResult();
        }
    }
}
