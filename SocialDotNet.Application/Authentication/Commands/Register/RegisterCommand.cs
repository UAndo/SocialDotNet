using ErrorOr;
using MediatR;
using SocialDotNet.Application.Authentication.Common;

namespace SocialDotNet.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
