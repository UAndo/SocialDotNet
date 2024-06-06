
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Common.Interfaces.Persistence
{
    public interface IFriendRequestRepository
    {
        Task<FriendRequest?> GetByIdAsync(FriendRequestId id);
        Task<IEnumerable<FriendRequest>> GetAllAsync();
        Task<IEnumerable<FriendRequest>> GetBySenderIdAsync(UserId senderId);
        Task<IEnumerable<FriendRequest>> GetByReceiverIdAsync(UserId receiverId);
        Task AddAsync(FriendRequest friendRequest);
        Task UpdateAsync(FriendRequest friendRequest);
        Task RemoveAsync(FriendRequest friendRequest);
    }
}
