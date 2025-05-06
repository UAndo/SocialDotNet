using ErrorOr;
using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.ValueObjects;
using System.Linq;
using SocialDotNet.Domain.Common.Errors;

namespace SocialDotNet.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsVerified { get; private set; }
        public string? VerificationCode { get; private set; }
        public DateTime VerificationCodeExpiration { get; private set; }
        public string? PasswordResetCode { get; private set; }
        public DateTime PasswordResetCodeExpiration { get; private set; }
        public string? ProfileImage { get; private set; }
        public string? Bio { get; private set; }
        public List<RefreshToken> RefreshTokens { get; private set; }
        private readonly List<Friendship> _friendships = [];
        public IReadOnlyList<Friendship> Friendships => _friendships.AsReadOnly();

        private readonly List<FriendRequest> _friendRequests = [];
        public IReadOnlyList<FriendRequest> FriendRequests => _friendRequests.AsReadOnly();

        private User(
            UserId Id,
            string firstName,
            string lastName,
            string username,
            string email,
            string passwordHash,
            List<RefreshToken> refreshToken) : base(Id)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
            RefreshTokens = refreshToken;
        }

        private User()
        {
        }

        public static User Create(
            string firstName,
            string lastName,
            string username,
            string email,
            string passwordHash,
            List<RefreshToken> refreshTokens)
        {
            var user = new User(UserId.CreateUnique(), firstName, lastName, username,
                email, passwordHash, refreshTokens);

            return user;
        }

        public void AddFriendRequest(FriendRequest friendRequest)
        {
            if (!_friendRequests.Contains(friendRequest))
            {
                _friendRequests.Add(friendRequest);
            }
        }

        public void AcceptFriendRequest(FriendRequest friendRequest)
        {
            _friendRequests.FirstOrDefault(x => x.Id == friendRequest.Id)?.Accept();
        }

        public void RejectFriendRequest(FriendRequest friendRequest)
        {
            _friendRequests.FirstOrDefault(x => x.Id == friendRequest.Id)?.Reject();
        }

        public void AddFriendship(Friendship friendship)
        {
            if (!_friendships.Contains(friendship))
            {
                _friendships.Add(friendship);
            }
        }

        public void RemoveFriendship(Friendship friendship)
        {
            if (_friendships.Contains(friendship))
            {
                _friendships.Remove(friendship);
            }
        }

        public ErrorOr<Success> RevokeRefreshToken(RefreshToken token, string reason, string? replacedByToken = null)
        {
            var refreshToken = RefreshTokens.SingleOrDefault(x => x.Token == token.Token);

            if (refreshToken is null || !refreshToken.IsActive)
                return Errors.Token.InvalidToken;

            refreshToken.Revoke(replacedByToken, reason);

            return Result.Success;
        }

        // --- DDD: логіка керування refresh токенами ---

        public void AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshTokens.Add(refreshToken);
        }

        public ErrorOr<Success> RotateRefreshToken(RefreshToken oldToken, RefreshToken newRefreshToken, string reason)
        {
            var refreshToken = RefreshTokens.SingleOrDefault(x => x.Token == oldToken.Token);
            if (refreshToken is null || !refreshToken.IsActive)
                return Errors.Token.InvalidToken;
            refreshToken.Revoke(newRefreshToken.Token, reason);
            AddRefreshToken(newRefreshToken);
            return Result.Success;
        }

        public void RemoveOldRefreshTokens(int ttlDays)
        {
            var now = DateTime.UtcNow;
            RefreshTokens = RefreshTokens
                .Where(x => x.IsActive || x.Created.AddDays(ttlDays) > now)
                .ToList();
        }

        public void RevokeDescendantRefreshTokens(RefreshToken token, string reason)
        {
            var childToken = RefreshTokens.SingleOrDefault(x => x.ReplacedByToken == token.Token);
            if (childToken != null && childToken.IsActive)
            {
                childToken.Revoke(null, reason);
                RevokeDescendantRefreshTokens(childToken, reason);
            }
        }
    }
}
