using Microsoft.EntityFrameworkCore;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.ChatAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Repositories
{
    public class ChatMemberRepository : IChatMemberRepository
    {
        private readonly DataContext _dbContext;

        public ChatMemberRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ChatMember?> GetByIdAsync(ChatMemberId id)
        {
            return await _dbContext.ChatMembers.FindAsync(id);
        }

        public async Task<IEnumerable<ChatMember>> GetAllAsync()
        {
            return await _dbContext.ChatMembers.ToListAsync();
        }

        public async Task<IEnumerable<ChatMember>> GetByChatIdAsync(ChatId chatId)
        {
            return await _dbContext.ChatMembers
                .Where(p => p.ChatId == chatId)
                .ToListAsync();
        }

        public async Task AddAsync(ChatMember chatMember)
        {
            await _dbContext.ChatMembers.AddAsync(chatMember);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(ChatMember chatMember)
        {
            _dbContext.ChatMembers.Remove(chatMember);
            await _dbContext.SaveChangesAsync();
        }
    }
}
