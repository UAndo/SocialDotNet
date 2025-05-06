using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialDotNet.Application.Authentication.Commands.Register;
using SocialDotNet.Application.FriendRequests.Commands.AcceptFriendRequest;
using SocialDotNet.Application.FriendRequests.Commands.CreateFriendRequest;
using SocialDotNet.Application.FriendRequests.Commands.RejectFriendRequest;
using SocialDotNet.Application.FriendRequests.Queries.GetFriendRequests;
using SocialDotNet.Application.Friendships.Commands.CreateFriendship;
using SocialDotNet.Application.Friendships.Commands.RemoveFriendship;
using SocialDotNet.Application.Friendships.Queries;
using SocialDotNet.Contracts.Friends;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Server.Controllers
{
    [Route("api/friends")]
    public class FriendsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FriendsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("get-all-friends")]
        public async Task<IActionResult> GetAllFriendsByUserId([FromQuery] Guid userId)
        {
            var command = _mapper.Map<GetFriendsQuery>(userId);
            var result = await _mediator.Send(command);
            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }

        [HttpPost("create-friend-request")]
        public async Task<IActionResult> CreateFriendRequest([FromBody] CreateFriendRequest request)
        {
            var command = _mapper.Map<SendFriendRequestCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }

        [HttpPost("accept-friend-request")]
        public async Task<IActionResult> AcceptFriendRequest([FromBody] FriendshipRequest request)
        {
            var command = _mapper.Map<AcceptFriendRequestCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }

        [HttpPost("reject-friend-request")]
        public async Task<IActionResult> RejectFriendRequest([FromBody] FriendshipRequest request)
        {
            var command = _mapper.Map<RejectFriendRequestCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }
        
        [HttpGet("get-friend-requests")]
        public async Task<IActionResult> GetFriendRequests([FromQuery] GetFriendsRequest request)
        {
            var command = _mapper.Map<GetFriendRequestsQuery>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }

        [HttpDelete("remove-friendship")]
        public async Task<IActionResult> RemoveFriendship([FromBody] FriendshipRequest request)
        {
            var command = _mapper.Map<RemoveFriendshipCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }
    }
}
