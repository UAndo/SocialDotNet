using SocialDotNet.Domain.ChatAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;
using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Domain.ChatAggregate
{
    public sealed class Chat : AggregateRoot<ChatId>
    {
        public string Name { get; private set; }
        public bool IsPersonalChat { get; private set; }
        public string Image { get; private set; }
        private readonly List<ChatMember> _chatMembers;
        public IReadOnlyList<ChatMember> ChatMembers => _chatMembers.AsReadOnly();
        private readonly List<Message> _messages;
        public IReadOnlyList<Message> Messages => _messages.AsReadOnly();

        private Chat(
            ChatId id,
            string name,
            bool isPersonalChat,
            List<ChatMember> chatMembers,
            List<Message> messages) : base(id)
        {
            Name = name;
            IsPersonalChat = isPersonalChat;
            _chatMembers = chatMembers ?? throw new ArgumentNullException(nameof(chatMembers));
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
        }

        private Chat()
        {
            _chatMembers = new List<ChatMember>();
            _messages = new List<Message>();
        }

        public static Chat Create(string name, bool isPersonalChat, List<ChatMember> chatMembers)
        {
            if (chatMembers == null || chatMembers.Count == 0)
                throw new ArgumentException("Chat members list cannot be null or empty", nameof(chatMembers));

            var chat = new Chat(ChatId.CreateUnique(), name, isPersonalChat, chatMembers, []);
            foreach (var member in chatMembers)
            {
                member.SetChatId(chat.Id);
            }
            return chat;
        }

        public void AddMessage(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            _messages.Add(message);
        }

        public void AddMember(ChatMember chatMember)
        {
            ArgumentNullException.ThrowIfNull(chatMember);
            if (!_chatMembers.Contains(chatMember))
            {
                chatMember.SetChatId(this.Id);
                _chatMembers.Add(chatMember);
            }
        }

        public void RemoveMember(ChatMember chatMember)
        {
            ArgumentNullException.ThrowIfNull(chatMember);
            _chatMembers.Remove(chatMember);
        }
    }
}
