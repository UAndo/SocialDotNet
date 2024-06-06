using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Application.FriendRequests.Commands.AcceptFriendRequest;

namespace SocialDotNet.Application.FriendRequests.Commands.AcceptFriendRequest
{
    public class AcceptFriendRequestCommandHandler : IRequestHandler<AcceptFriendRequestCommand>
    {
        private readonly IFriendRequestRepository _friendRequestRepository;

        public AcceptFriendRequestCommandHandler(IFriendRequestRepository friendRequestRepository)
        {
            _friendRequestRepository = friendRequestRepository;
        }

        public async Task Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var friendRequest = await _friendRequestRepository.GetByIdAsync(request.FriendRequestId);
            friendRequest!.Accept();
            await _friendRequestRepository.UpdateAsync(friendRequest);
        }
    }
}
