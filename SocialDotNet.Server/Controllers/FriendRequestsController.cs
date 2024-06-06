using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialDotNet.Application.FriendRequests.Commands.AcceptFriendRequest;
using SocialDotNet.Application.FriendRequests.Commands.CreateFriendRequest;
using SocialDotNet.Application.FriendRequests.Commands.RejectFriendRequest;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Server.Controllers
{
    [Route("friend-requests")]
    public class FriendRequestsController : ApiController
    {
        private readonly IMediator _mediator;

        public FriendRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-friend-request")]
        public async Task<IActionResult> CreateFriendRequest([FromBody] CreateFriendRequestCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("accept-friend-request/{id}/accept")]
        public async Task<IActionResult> AcceptFriendRequest(FriendRequestId id)
        {
            await _mediator.Send(new AcceptFriendRequestCommand(id));
            return NoContent();
        }

        [HttpPost("reject-friend-request/{id}/reject")]
        public async Task<IActionResult> RejectFriendRequest(FriendRequestId id)
        {
            await _mediator.Send(new RejectFriendRequestCommand(id));
            return NoContent();
        }
    }
}
