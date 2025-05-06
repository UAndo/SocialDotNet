using ErrorOr;
using MediatR;

namespace SocialDotNet.Application.Authentication.Commands.RevokeToken
{
    public record RevokeTokenCommand(
        string Token) : IRequest<ErrorOr<Success>>;
}
