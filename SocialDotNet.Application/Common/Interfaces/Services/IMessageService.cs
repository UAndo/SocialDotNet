namespace SocialDotNet.Application.Common.Interfaces.Services
{
    public interface IMessageService
    {
        Task SendMessageToChatAsync(string chatId, string message);
    }
}
