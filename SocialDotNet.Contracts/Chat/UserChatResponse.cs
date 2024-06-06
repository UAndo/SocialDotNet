namespace SocialDotNet.Contracts.Chat
{
    public record UserChatResponse(
        string Id,
        string Name,
        string LastMessage);
}
