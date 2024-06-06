using SocialDotNet.Domain.ChatAggregate.Enums;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;
using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.ValueObjects;
using System;

namespace SocialDotNet.Domain.ChatAggregate.Entities
{
    public sealed class Message : Entity<MessageId>
    {
        public UserId SenderId { get; private set; }
        public ChatId ChatId { get; private set; }
        public string Content { get; private set; }
        public DateTime SentAt { get; private set; }
        public MessageStatus Status { get; private set; }

        private Message(
            MessageId id,
            UserId senderId,
            ChatId chatId,
            string content,
            DateTime sentAt) : base(id)
        {
            SenderId = senderId;
            ChatId = chatId;
            Content = content;
            Status = MessageStatus.Sent;
            SentAt = sentAt;
        }

        private Message() { }

        public static Message Create(UserId senderId, ChatId chatId, string content)
        {
            return new Message(
                MessageId.CreateUnique(),
                senderId,
                chatId,
                content,
                DateTime.UtcNow);
        }
    }
}
