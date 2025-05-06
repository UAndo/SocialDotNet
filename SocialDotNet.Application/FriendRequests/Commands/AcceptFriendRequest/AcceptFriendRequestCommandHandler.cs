using ErrorOr;
using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.Entities;

namespace SocialDotNet.Application.FriendRequests.Commands.AcceptFriendRequest
{
    public class AcceptFriendRequestCommandHandler : IRequestHandler<AcceptFriendRequestCommand, ErrorOr<Unit>>
    {
        private readonly IFriendRequestRepository _friendRequestRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IUserRepository _userRepository;

        public AcceptFriendRequestCommandHandler(IFriendRequestRepository friendRequestRepository, IFriendshipRepository friendshipRepository, IUserRepository userRepository)
        {
            _friendRequestRepository = friendRequestRepository;
            _friendshipRepository = friendshipRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(AcceptFriendRequestCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);
            var friendRequest = user.FriendRequests.FirstOrDefault(fr => fr.Id == command.FriendId);
            var friendship = Friendship.Create(user.Id, friendRequest.SenderId);
            user.AddFriendship(friendship);
            user.AcceptFriendRequest(friendRequest);
            await _userRepository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
