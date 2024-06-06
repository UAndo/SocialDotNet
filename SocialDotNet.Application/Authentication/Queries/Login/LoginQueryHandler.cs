using ErrorOr;
using MediatR;
using SocialDotNet.Application.Authentication.Common;
using SocialDotNet.Application.Common.Interfaces.Authentication;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.Common.Errors;
using SocialDotNet.Domain.UserAggregate;

namespace SocialDotNet.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (await _userRepository.GetUserByEmailAsync(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (!BC.EnhancedVerify(query.Password, user.PasswordHash))
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);

            _jwtTokenGenerator.RemoveOldRefreshTokens(user);

            await _userRepository.UpdateAsync(user);

            return new AuthenticationResult(
                user,
                token,
                refreshToken.Token);
        }
    }
}
