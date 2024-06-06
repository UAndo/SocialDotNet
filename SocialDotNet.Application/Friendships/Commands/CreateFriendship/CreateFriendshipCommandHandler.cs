using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.UserAggregate.Entities;

namespace SocialDotNet.Application.Friendships.Commands.CreateFriendship
{
    public class CreateFriendshipCommandHandler : IRequestHandler<CreateFriendshipCommand>
    {
        private readonly IFriendshipRepository _friendshipRepository;

        public CreateFriendshipCommandHandler(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public async Task Handle(CreateFriendshipCommand request, CancellationToken cancellationToken)
        {
            var friendship = Friendship.Create(request.UserId, request.FriendId);
            await _friendshipRepository.AddAsync(friendship);
        }
    }
}
