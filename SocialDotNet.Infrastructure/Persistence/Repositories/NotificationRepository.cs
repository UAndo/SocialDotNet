using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public Task AddNotificationAsync(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNotificationAsync(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task<Notification?> GetNotificationByIdAsync(NotificationId notificationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Notification>> GetNotificationsByUserIdAsync(UserId userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNotificationAsync(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
