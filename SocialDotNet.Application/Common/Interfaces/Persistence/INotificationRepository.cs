using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Common.Interfaces.Persistence
{
    public interface INotificationRepository
    {
        Task AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(Notification notification);
        Task<Notification?> GetNotificationByIdAsync(NotificationId notificationId);
        Task<List<Notification>> GetNotificationsByUserIdAsync(UserId userId);
    }
}
