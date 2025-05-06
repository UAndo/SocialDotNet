using ErrorOr;
using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.FriendRequests.Commands.CreateFriendRequest
{
    public class SendFriendRequestCommandHandler : IRequestHandler<SendFriendRequestCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;

        public SendFriendRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var  friend = await _userRepository.GetByNameAsync(request.FriendName);
            if (friend != null) 
            {
                var friendRequest = FriendRequest.Create(request.UserId, friend.Id);
                friend.AddFriendRequest(friendRequest);
                await _userRepository.UpdateAsync(friend);
            }
            return Unit.Value;
        }
    }
}
