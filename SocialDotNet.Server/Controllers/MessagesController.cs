using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialDotNet.Application.Chats.Commands.SaveMessage;
using SocialDotNet.Application.Common.Interfaces.Services;
using SocialDotNet.Contracts.Chat;
using SocialDotNet.Domain.Common.Errors;

namespace SocialDotNet.Server.Controllers
{   
    [Route("api/messages")]
    public class MessageController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;
        private readonly INotificationService _notificationService;

        public MessageController(
            IMediator mediator,
            IMapper mapper,
            IMessageService messageService,
            INotificationService notificationService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _messageService = messageService;
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage(SendMessageRequest request)
        {
            var command = _mapper.Map<SaveMessageCommand>(request);
            var sendResult = await _mediator.Send(command);

            if (sendResult.IsError)
            {
                var firstError = sendResult.FirstError;
                if (firstError == Errors.Message.InvalidRecipient)
                {
                    return Problem(
                        statusCode: StatusCodes.Status400BadRequest,
                        title: firstError.Description);
                }

                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "An unexpected error occurred.");
            }

            await _messageService.SendMessageToChatAsync(request.ChatId.ToString(), request.Content);
            await _notificationService.SendNewMessageNotification(request.ChatId.ToString(), "New message received");

            return sendResult.Match(
                result =>
                {
                    var response = _mapper.Map<SaveMessageResponse>(result);
                    return Ok(response);
                },
                errors =>
                {
                    return Problem(errors);
                });
        }
    }
}
