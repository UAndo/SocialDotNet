using SocialDotNet.Domain.Common.Models;
using SocialDotNet.Domain.UserAggregate.Entities;
using SocialDotNet.Domain.UserAggregate.Enums;
using SocialDotNet.Domain.UserAggregate.ValueObjects;

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
        public string VerificationCode { get; private set; }
        public DateTime VerificationCodeExpiration { get; private set; }
        public string PasswordResetCode { get; private set; }
        public DateTime PasswordResetCodeExpiration { get; private set; }
        public string ProfileImage { get; private set; }
        public string Bio { get; private set; }
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
    }
}