using Microsoft.AspNetCore.SignalR;
using SocialDotNet.Application.Common.Interfaces.Services;
using SocialDotNet.Server.Hubs;

namespace SocialDotNet.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IHubContext<ChatHub> _chatHubContext;

        public MessageService(IHubContext<ChatHub> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }

        public async Task SendMessageToChatAsync(string chatId, string message)
        {
            await _chatHubContext.Clients.Group(chatId).SendAsync("ReceiveMessage", message);
        }
    }
}
