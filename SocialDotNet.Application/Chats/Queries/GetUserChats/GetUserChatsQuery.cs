using MediatR;
using SocialDotNet.Application.Chats.Common;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Chats.Queries.GetUserChats
{
    public record GetUserChatsQuery(
        UserId UserId) : IRequest<List<ChatDto>>;
}
