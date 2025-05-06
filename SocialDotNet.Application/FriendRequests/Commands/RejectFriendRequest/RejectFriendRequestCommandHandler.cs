using ErrorOr;
using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Application.FriendRequests.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialDotNet.Application.FriendRequests.Commands.RejectFriendRequest
{
    public class RejectFriendRequestCommandHandler : IRequestHandler<RejectFriendRequestCommand, ErrorOr<Unit>>
    {
        private readonly  IUserRepository _userRepository;

        public RejectFriendRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(RejectFriendRequestCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);
            var friendRequest = user.FriendRequests.FirstOrDefault(fr => fr.Id == command.FriendRequestId);
            user.RejectFriendRequest(friendRequest);
            await _userRepository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
