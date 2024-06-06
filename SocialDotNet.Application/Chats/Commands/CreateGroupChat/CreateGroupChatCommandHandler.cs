using MediatR;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.ChatAggregate;
using SocialDotNet.Domain.ChatAggregate.Entities;

namespace SocialDotNet.Application.Chats.Commands.CreateGroupChat
{

    public class CreateGroupChatCommandHandler : IRequestHandler<CreateGroupChatCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;

        public CreateGroupChatCommandHandler(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(CreateGroupChatCommand request, CancellationToken cancellationToken)
        {
            var chatMembers = new List<ChatMember>();

            foreach (var member in request.ChatMembers)
            {
                chatMembers.Add(ChatMember.Create(member.UserId, member.FirstName, member.LastName));
            }

            var groupChat = Chat.Create(request.ChatName, false ,chatMembers);

            await _chatRepository.AddAsync(groupChat);
        }
    }
}
