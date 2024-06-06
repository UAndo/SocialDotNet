using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.ChatAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;

namespace SocialDotNet.Infrastructure.Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Task DeleteMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetMessagesByChatIdAsync(ChatId id)
        {
            throw new NotImplementedException();
        }

        public Task SaveMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
