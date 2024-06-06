using Microsoft.EntityFrameworkCore;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.ChatAggregate;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly DataContext _context;

        public ChatRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Chat chat)
        {
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetChatsForUserAsync(UserId userId)
        {
            return await _context.Chats
                .Include(c => c.ChatMembers)
                .Include(c => c.Messages)
                .Where(c => c.ChatMembers.Any(p => p.UserId == userId))
                .ToListAsync();
        }

        public async Task<List<Chat>> GetGroupChatsForUserAsync(UserId userId)
        {
            return await _context.Chats
               .Include(c => c.ChatMembers)
               .Include(c => c.Messages)
               .Where(c => c.IsPersonalChat == false)
               .ToListAsync();
        }

        public async Task<List<Chat>> GetPersonalChatsForUserAsync(UserId userId)
        {
            return await _context.Chats
               .Include(c => c.ChatMembers)
               .Include(c => c.Messages)
               .Where(c => c.IsPersonalChat == true)
               .ToListAsync();
        }
    }
}
