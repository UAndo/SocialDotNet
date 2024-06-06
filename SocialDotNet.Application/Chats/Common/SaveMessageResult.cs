using SocialDotNet.Domain.ChatAggregate.ValueObjects;

namespace SocialDotNet.Application.Chats.Common
{
    public record SaveMessageResult(
        MessageId MessageId,
        ChatId ChatId);
}
