using FluentValidation;

namespace SocialDotNet.Application.Authentication.Commands.RevokeToken
{
    public class RevokeTokenCommandValidator : AbstractValidator<RevokeTokenCommand>
    {
        public RevokeTokenCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
