using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;

namespace SocialDotNet.Application.FriendRequests.Commands.RejectFriendRequest
{
    public class RejectFriendRequestCommandHandler : IRequestHandler<RejectFriendRequestCommand>
    {
        private readonly IFriendRequestRepository _friendRequestRepository;

        public RejectFriendRequestCommandHandler(IFriendRequestRepository friendRequestRepository)
        {
            _friendRequestRepository = friendRequestRepository;
        }

        public async Task Handle(RejectFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var friendRequest = await _friendRequestRepository.GetByIdAsync(request.FriendRequestId);
            friendRequest!.Reject();
            await _friendRequestRepository.UpdateAsync(friendRequest);
        }
    }
}
