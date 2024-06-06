using ErrorOr;
using MediatR;
using SocialDotNet.Application.Chats.Common;
using SocialDotNet.Application.Common.Interfaces.Persistence;

namespace SocialDotNet.Application.Chats.Commands.SaveMessage
{
    public class SaveMessageCommandHandler : IRequestHandler<SaveMessageCommand, ErrorOr<SaveMessageResult>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly INotificationRepository _notificationRepository;

        public SaveMessageCommandHandler(IMessageRepository messageRepository, INotificationRepository notificationRepository)
        {
            _messageRepository = messageRepository;

        }
        public Task<ErrorOr<SaveMessageResult>> Handle(SaveMessageCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
