using SocialDotNet.Domain.ChatAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate.ValueObjects;

namespace SocialDotNet.Application.Chats.Common
{
    public record ChatDto(
        ChatId Id,
        string Name,
        string AvatarUrl,
        Message LastMessage);
}
