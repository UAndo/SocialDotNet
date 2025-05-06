using ErrorOr;
using MediatR;
using SocialDotNet.Application.Authentication.Common;
using SocialDotNet.Application.Common.Interfaces.Authentication;
using SocialDotNet.Application.Common.Interfaces.Persistence;
using SocialDotNet.Domain.Common.Errors;
using SocialDotNet.Domain.UserAggregate;

namespace SocialDotNet.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (await _userRepository.GetUserByEmailAsync(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var hashedPassword = BC.EnhancedHashPassword(command.Password, 13);

            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

            var user = User.Create(command.FirstName, command.LastName, command.Username, command.Email, hashedPassword, [refreshToken]);

            var token = _jwtTokenGenerator.GenerateToken(user);

            await _userRepository.AddAsync(user);   

            return new AuthenticationResult(
                user,
                token,
                refreshToken.Token);
        }
    }
}
