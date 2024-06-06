using Microsoft.AspNetCore.SignalR;
using SocialDotNet.Application.Common.Interfaces.Services;
using SocialDotNet.Server.Hubs;

namespace SocialDotNet.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public NotificationService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNewMessageNotification(string chatId, string message)
        {
            await _hubContext.Clients.Group(chatId).SendAsync("ReceiveMessage", message);
        }

        public async Task SendFriendRequestNotification(string userId, string notification)
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceiveFriendRequest", notification);
        }

        public async Task SendChannelPostNotification(string channelId, string post)
        {
            await _hubContext.Clients.Group(channelId).SendAsync("ReceiveChannelPost", post);
        }
    }
}
