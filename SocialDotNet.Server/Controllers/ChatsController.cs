using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialDotNet.Application.Chats.Commands.CreateGroupChat;
using SocialDotNet.Application.Chats.Commands.CreatePersonalChat;
using SocialDotNet.Application.Chats.Queries.GetUserChats;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Server.Controllers
{
    [Route("chats")]
    public class ChatsController : ApiController
    {
        private readonly ISender _mediator;

        public ChatsController(ISender sender)
        {
            _mediator = sender;
        }

        [HttpGet("get-chats-for-user/{userId}")]
        public async Task<IActionResult> GetChatsForUser(Guid userId)
        {
            var command = new GetUserChatsQuery(UserId.Create(userId));
            var chats = await _mediator.Send(command);
            return Ok(chats);
        }

        [HttpPost("create-personal-chat/{userId1}&{userId2}")]
        public async Task<IActionResult> CreatePersonalChat(Guid userId1, Guid userId2)
        {
            var command = new CreatePersonalChatCommand(UserId.Create(userId1),
                UserId.Create(userId2));
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("create-group-chat")]
        public async Task<IActionResult> CreateGroupChat(CreateGroupChatCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
