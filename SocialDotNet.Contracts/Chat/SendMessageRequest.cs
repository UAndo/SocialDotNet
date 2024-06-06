namespace SocialDotNet.Contracts.Chat
{
    public record SendMessageRequest(
        Guid ChatId,
        Guid SenderId,
        string Content
    );

}
