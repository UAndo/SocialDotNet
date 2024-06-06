namespace SocialDotNet.Application.Chats.Common
{
    public record MessageDto(
        Guid MessageId,
        string Content,
        DateTime SentAt,
        Guid SenderId);
}
