using Microsoft.EntityFrameworkCore;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.GroupAggregate;

namespace SocialDotNet.Infrastructure.Persistence.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Group group)
        {
            _context.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Group group)
        {
            _context.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group?> GetByIdAsync(Guid id)
        {
            return await _context.Groups.FirstOrDefaultAsync(x => x.Id.Value == id);
        }

        public async Task<Group?> GetByNameAsync(string name)
        {
            return await _context.Groups.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Update(group);
            await _context.SaveChangesAsync();
        }
    }
}
