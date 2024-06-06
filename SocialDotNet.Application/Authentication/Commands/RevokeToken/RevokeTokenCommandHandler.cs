using ErrorOr;
using MediatR;
using SocialDotNet.Application.Common.Interfaces.Authentication;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.Common.Errors;

namespace SocialDotNet.Application.Authentication.Commands.RevokeToken
{
    public class RevokeTokenCommandHandler :
        IRequestHandler<RevokeTokenCommand, ErrorOr<Unit>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RevokeTokenCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<Unit>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserByRefreshTokenAsync(request.Token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);

            if (!refreshToken.IsActive)
                return Errors.Token.InvalidToken;

            // revoke token and save
            _jwtTokenGenerator.RevokeRefreshToken(refreshToken, "Revoked without replacement");
            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
