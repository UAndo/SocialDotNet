using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.ChatAggregate.Entities;
using SocialDotNet.Domain.ChatAggregate;
using MediatR;

namespace SocialDotNet.Application.Chats.Commands.CreatePersonalChat
{
    public class CreatePersonalChatCommandHandler : IRequestHandler<CreatePersonalChatCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;

        public CreatePersonalChatCommandHandler(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(CreatePersonalChatCommand request, CancellationToken cancellationToken)
        {
            var user1 = await _userRepository.GetByIdAsync(request.UserId1);
            var user2 = await _userRepository.GetByIdAsync(request.UserId2);

            var chat = Chat.Create(string.Empty, true,
        [
            ChatMember.Create(request.UserId1,user2!.FirstName, user2.LastName),
            ChatMember.Create(request.UserId2, user1!.FirstName, user1.LastName)
        ]);

            await _chatRepository.AddAsync(chat);
        }
    }
}
