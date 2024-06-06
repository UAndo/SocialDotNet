using SocialDotNet.Domain.ChatAggregate.ValueObjects;
using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Domain.ChatAggregate.Entities
{
    public class ChatMember : Entity<ChatMemberId>
    {
        public UserId UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public ChatId ChatId { get; private set; }
        public DateTime JoinedAt { get; private set; }

        private ChatMember(ChatMemberId id, UserId userId, string firstName, string lastName, string profileImage) : base(id)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            JoinedAt = DateTime.UtcNow;
        }

        public static ChatMember Create(UserId userId, string firstName, string lastName, string profileImage = "")
        {
            return new ChatMember(ChatMemberId.CreateUnique(), userId, firstName, lastName, profileImage);
        }

        public void SetChatId(ChatId chatId)
        {
            ChatId = chatId;
        }

        private ChatMember() { }
    }
}
