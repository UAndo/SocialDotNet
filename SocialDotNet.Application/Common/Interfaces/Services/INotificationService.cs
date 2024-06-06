using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDotNet.Application.Common.Interfaces.Services
{
    public interface INotificationService
    {
        Task SendNewMessageNotification(string chatId, string message);

        Task SendFriendRequestNotification(string userId, string notification);

        Task SendChannelPostNotification(string channelId, string post);
    }
}
