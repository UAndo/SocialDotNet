using ErrorOr;
using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Application.FriendRequests.Common;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialDotNet.Application.FriendRequests.Queries.GetFriendRequests
{
    public class GetFriendRequestsQueryHandler : IRequestHandler<GetFriendRequestsQuery, ErrorOr<List<FriendRequestResult>>>
    {
        private readonly IUserRepository _userRepository;

        public GetFriendRequestsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<List<FriendRequestResult>>> Handle(GetFriendRequestsQuery command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);

            if (user == null)
            {
                return Error.Failure("UserNotFound", "User not found.");
            }

            var friendRequestResults = new List<FriendRequestResult>();

            foreach (var friendRequest in user.FriendRequests)
            {
                var sender = await _userRepository.GetByIdAsync(friendRequest.SenderId);
                var receiver = await _userRepository.GetByIdAsync(friendRequest.ReceiverId);

                if (sender == null || receiver == null)
                {
                    continue; 
                }

                var friendInfo = sender.Id == command.UserId ? receiver : sender;

                friendRequestResults.Add(new FriendRequestResult(
                    friendRequest.Id.Value, 
                    friendInfo.ProfileImage,       
                    friendInfo.Username,     
                    friendRequest.Status.ToString()
                ));
            }

            return friendRequestResults;
        }
    }
}
