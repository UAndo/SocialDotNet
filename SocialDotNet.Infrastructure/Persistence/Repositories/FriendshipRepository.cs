using Microsoft.EntityFrameworkCore;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly DataContext _dbContext;

        public FriendshipRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Friendship?> GetByIdAsync(FriendshipId id)
        {
            return await _dbContext.Friendships.FindAsync(id);
        }

        public async Task<IEnumerable<Friendship>> GetAllAsync()
        {
            return await _dbContext.Friendships.ToListAsync();
        }

        public async Task<IEnumerable<Friendship>> GetByUserIdAsync(UserId userId)
        {
            return await _dbContext.Friendships
                .Where(f => f.UserId == userId || f.FriendId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Friendship friendship)
        {
            await _dbContext.Friendships.AddAsync(friendship);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Friendship friendship)
        {
            _dbContext.Friendships.Remove(friendship);
            await _dbContext.SaveChangesAsync();
        }
    }
}
