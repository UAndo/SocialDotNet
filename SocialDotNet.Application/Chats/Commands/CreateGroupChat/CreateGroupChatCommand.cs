using MediatR;
using SocialDotNet.Domain.ChatAggregate.Entities;

namespace SocialDotNet.Application.Chats.Commands.CreateGroupChat
{
    public record CreateGroupChatCommand(
        string ChatName,
        List<ChatMember> ChatMembers) : IRequest;
}
