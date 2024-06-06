using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;

namespace SocialDotNet.Application.Friendships.Commands.RemoveFriendship
{
    public class RemoveFriendshipCommandHandler : IRequestHandler<RemoveFriendshipCommand>
    {
        private readonly IFriendshipRepository _friendshipRepository;

        public RemoveFriendshipCommandHandler(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public async Task Handle(RemoveFriendshipCommand request, CancellationToken cancellationToken)
        {
            var friendship = await _friendshipRepository.GetByIdAsync(request.FriendshipId);
            await _friendshipRepository.RemoveAsync(friendship!);
        }
    }
}
