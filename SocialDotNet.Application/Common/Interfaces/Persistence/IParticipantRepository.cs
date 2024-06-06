using SocialDotNet.Domain.ChatAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;

namespace SocialDotNet.Application.Common.Interfaces.Persistence
{
    public interface IChatMemberRepository
    {
        Task<ChatMember?> GetByIdAsync(ChatMemberId id);
        Task<IEnumerable<ChatMember>> GetAllAsync();
        Task<IEnumerable<ChatMember>> GetByChatIdAsync(ChatId chatId);
        Task AddAsync(ChatMember chatMember);
        Task RemoveAsync(ChatMember chatMember);
    }
}
