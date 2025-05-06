using MediatR;
using SocialDotNet.Application.Chats.Common;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Chats.Queries.GetUserChats
{   
    public class GetUserChatsQueryHandler : IRequestHandler<GetUserChatsQuery, List<ChatDto>>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;

        public GetUserChatsQueryHandler(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public async Task<List<ChatDto>> Handle(GetUserChatsQuery request, CancellationToken cancellationToken)
        {
            var personalChats = await GetPersonalChats(request.UserId);
            var groupChats = await GetGroupChats(request.UserId);

            return [.. personalChats, .. groupChats];
        }

        private async Task<List<ChatDto>> GetPersonalChats(UserId userId)
        {
            var personalChats = await _chatRepository.GetPersonalChatsForUserAsync(userId);
            var personalChatDtos = new List<ChatDto>();

            foreach (var chat in personalChats)
            {
                var messages = chat.Messages[chat.Messages.Count - 1];

                string name;
                string avatarUrl;

                var chatMember = chat.ChatMembers.FirstOrDefault(cm => cm.UserId != userId);
                if (chatMember != null)
                {
                    var user = await _userRepository.GetByIdAsync(chatMember.UserId);
                    name = $"{user.FirstName} {user.LastName}";
                    avatarUrl = user.ProfileImage;
                }
                else
                {
                    name = chat.Name;
                    avatarUrl = string.Empty; 
                }

                var personalChatDto = new ChatDto(
                    chat.Id,
                    name,
                    avatarUrl,
                    messages
                );

                personalChatDtos.Add(personalChatDto);
            }

            return personalChatDtos;
        }

        private async Task<List<ChatDto>> GetGroupChats(UserId userId)
        {
            var groupChats = await _chatRepository.GetGroupChatsForUserAsync(userId);
            var groupChatDtos = new List<ChatDto>();

            foreach (var chat in groupChats)
            {
                var message = chat.Messages[chat.Messages.Count - 1];

                var groupName = chat.Name;
                var groupAvatarUrl = "";

                var groupChatDto = new ChatDto(
                    chat.Id,
                    groupName,
                    groupAvatarUrl,
                    message
                );

                groupChatDtos.Add(groupChatDto);
            }

            return groupChatDtos;
        }

    }
}
