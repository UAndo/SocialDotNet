using Microsoft.EntityFrameworkCore;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Repositories
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly DataContext _dbContext;

        public FriendRequestRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FriendRequest?> GetByIdAsync(FriendRequestId id)
        {
            return await _dbContext.FriendRequests.FindAsync(id);
        }

        public async Task<IEnumerable<FriendRequest>> GetAllAsync()
        {
            return await _dbContext.FriendRequests.ToListAsync();
        }

        public async Task<IEnumerable<FriendRequest>> GetBySenderIdAsync(UserId senderId)
        {
            return await _dbContext.FriendRequests.Where(fr => fr.SenderId == senderId).ToListAsync();
        }

        public async Task<IEnumerable<FriendRequest>> GetByReceiverIdAsync(UserId receiverId)
        {
            return await _dbContext.FriendRequests.Where(fr => fr.ReceiverId == receiverId).ToListAsync();
        }

        public async Task AddAsync(FriendRequest friendRequest)
        {
            await _dbContext.FriendRequests.AddAsync(friendRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(FriendRequest friendRequest)
        {
            _dbContext.FriendRequests.Update(friendRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(FriendRequest friendRequest)
        {
            _dbContext.FriendRequests.Remove(friendRequest);
            await _dbContext.SaveChangesAsync();
        }
    }

}
