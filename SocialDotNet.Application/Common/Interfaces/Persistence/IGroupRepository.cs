using SocialDotNet.Domain.GroupAggregate;

namespace SocialDotNet.Application.Common.Interfaces.Persistence
{
    public interface IGroupRepository
    {
        Task AddAsync(Group group);
        Task UpdateAsync(Group group);
        Task DeleteAsync(Group group);
        Task<Group?> GetByIdAsync(Guid id);
        Task<List<Group>> GetAllAsync();
        Task<Group?> GetByNameAsync(string name);
    }
}
