using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Common.Interfaces.Persistence
{
    public interface IFriendshipRepository
    {
        Task<Friendship?> GetByIdAsync(FriendshipId id);
        Task<IEnumerable<Friendship>> GetAllAsync();
        Task<IEnumerable<Friendship>> GetByUserIdAsync(UserId userId);
        Task AddAsync(Friendship friendship);
        Task RemoveAsync(Friendship friendship);
    }
}
