using SocialDotNet.Domain.UserAggregate;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

namespace SocialDotNet.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<User?> GetUserByRefreshTokenAsync(string refreshToken);
    Task<User?> GetByIdAsync(UserId id);
    Task<User?> GetByNameAsync(string friendName);
}
