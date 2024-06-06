using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialDotNet.Application.Friendships.Commands.CreateFriendship;
using SocialDotNet.Application.Friendships.Commands.RemoveFriendship;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Server.Controllers
{
    [ApiController]
    [Route("friendship")]
    public class FriendshipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendshipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-friendship")]
        public async Task<IActionResult> CreateFriendship([FromBody] CreateFriendshipCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("remove-friendship/{id}")]
        public async Task<IActionResult> RemoveFriendship(FriendshipId id)
        {
            await _mediator.Send(new RemoveFriendshipCommand(id));
            return NoContent();
        }
    }
}
