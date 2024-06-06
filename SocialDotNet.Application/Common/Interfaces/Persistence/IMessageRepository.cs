using SocialDotNet.Domain.ChatAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;

namespace SocialDotNet.Application.Common.Interfaces.Persistence
{
    public interface IMessageRepository
    {
        Task SaveMessageAsync(Message message);
        Task DeleteMessageAsync(Message message);
        Task UpdateMessageAsync(Message message);
        Task<Message> GetMessagesByChatIdAsync(ChatId id);
    }
}
