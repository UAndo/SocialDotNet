using ErrorOr;
using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Application.FriendRequests.Common;

namespace SocialDotNet.Application.Friendships.Commands.RemoveFriendship
{
    public class RemoveFriendshipCommandHandler : IRequestHandler<RemoveFriendshipCommand, ErrorOr<FriendshipResult>>
    {
        private readonly IUserRepository _userRepository;

        public RemoveFriendshipCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<FriendshipResult>> Handle(RemoveFriendshipCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);
            var friendship = user?.Friendships.FirstOrDefault(f => f.FriendId == command.FriendId);
            user.RemoveFriendship(friendship);
            await _userRepository.UpdateAsync(user);
            return new FriendshipResult();
        }
    }
}
