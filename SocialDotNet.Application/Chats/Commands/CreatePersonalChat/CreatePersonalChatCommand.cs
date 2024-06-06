using MediatR;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Chats.Commands.CreatePersonalChat
{
    public record CreatePersonalChatCommand(
        UserId UserId1,
        UserId UserId2) : IRequest;
}
