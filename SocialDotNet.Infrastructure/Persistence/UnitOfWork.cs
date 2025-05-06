using SocialDotNet.Application.Common.Interfaces.Persistence;

namespace SocialDotNet.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;


    public IChatRepository ChatRepository { get; }
    public IChatMemberRepository ChatMemberRepository { get; }
    public IUserRepository UserRepository { get; }
    public IFriendRequestRepository FriendRequestRepository { get; }
    public IFriendshipRepository FriendshipRepository { get; }
    public IMessageRepository MessageRepository { get; }
    public INotificationRepository NotificationRepository { get; }
    public IGroupRepository GroupRepository { get; }
    
    public UnitOfWork(DataContext context, IChatRepository chatRepository, IChatMemberRepository chatMemberRepository, IUserRepository userRepository, IFriendRequestRepository friendRequestRepository, IFriendshipRepository friendshipRepository, IMessageRepository messageRepository, INotificationRepository notificationRepository, IGroupRepository groupRepository)
    {
        _context = context;
        ChatRepository = chatRepository;
        ChatMemberRepository = chatMemberRepository;
        UserRepository = userRepository;
        FriendRequestRepository = friendRequestRepository;
        FriendshipRepository = friendshipRepository;
        MessageRepository = messageRepository;
        NotificationRepository = notificationRepository;
        GroupRepository = groupRepository;
    }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}