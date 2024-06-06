using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.UserAggregate.Entities;

namespace SocialDotNet.Application.FriendRequests.Commands.CreateFriendRequest
{
    public class CreateFriendRequestCommandHandler : IRequestHandler<CreateFriendRequestCommand>
    {
        private readonly IFriendRequestRepository _friendRequestRepository;

        public CreateFriendRequestCommandHandler(IFriendRequestRepository friendRequestRepository)
        {
            _friendRequestRepository = friendRequestRepository;
        }

        public async Task Handle(CreateFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var friendRequest = FriendRequest.Create(request.SenderId, request.ReceiverId);
            await _friendRequestRepository.AddAsync(friendRequest);
        }
    }
}
