using ErrorOr;
using MediatR;
using SocialDotNet.Application.Authentication.Common;

namespace SocialDotNet.Application.Authentication.Commands.UpdateRefreshToken
{
    public record UpdateRefreshTokenCommand(
        string RefreshToken) : IRequest<ErrorOr<AuthenticationResult>>;
}
