using ErrorOr;
using MediatR;
using SocialDotNet.Application.Authentication.Common;
using SocialDotNet.Application.Common.Interfaces.Authentication;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.Common.Errors;

namespace SocialDotNet.Application.Authentication.Commands.UpdateRefreshToken
{
    public class UpdateRefreshTokenCommandHandler :
        IRequestHandler<UpdateRefreshTokenCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public UpdateRefreshTokenCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(UpdateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserByRefreshTokenAsync(request.RefreshToken);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.RefreshToken);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                user.RevokeDescendantRefreshTokens(refreshToken, $"Attempted reuse of revoked ancestor token: {refreshToken}");
                await _userRepository.UpdateAsync(user);
            }

            if (!refreshToken.IsActive)
                return Errors.Token.InvalidToken;

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();
            user.RotateRefreshToken(refreshToken, newRefreshToken, "Replaced by new token");

            // remove old refresh tokens from user
            user.RemoveOldRefreshTokens(7);

            // save changes to db
            await _userRepository.UpdateAsync(user);

            // generate new jwt
            var jwtToken = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, jwtToken, newRefreshToken.Token);
        }
    }
}
