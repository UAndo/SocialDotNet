namespace SocialDotNet.Contracts.Chat
{
    public record SaveMessageResponse(
        Guid MessageId,
        Guid ChatId);
}
