namespace SocialDotNet.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    IChatRepository ChatRepository { get; }
    IChatMemberRepository ChatMemberRepository { get; }
    IUserRepository UserRepository { get; }
    IFriendRequestRepository FriendRequestRepository { get; }
    IFriendshipRepository FriendshipRepository { get; }
    IMessageRepository MessageRepository { get; }
    INotificationRepository NotificationRepository { get; }
    IGroupRepository GroupRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}