using SocialDotNet.Domain.ChatAggregate;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Common.Interfaces.Persistence
{
    public interface IChatRepository
    {
        Task AddAsync(Chat chat);
        Task<List<Chat>> GetChatsForUserAsync(UserId userId);
        Task<List<Chat>> GetPersonalChatsForUserAsync(UserId userId);
        Task<List<Chat>> GetGroupChatsForUserAsync(UserId userId);
    }
}
