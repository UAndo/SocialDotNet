using ErrorOr;
using MediatR;
using SocialDotNet.Application.Chats.Common;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;

namespace SocialDotNet.Application.Chats.Commands.SaveMessage
{
    public record SaveMessageCommand(
        ChatId ChatId,
        ChatMemberId SenderId,
        string Content) : IRequest<ErrorOr<SaveMessageResult>>;
}
