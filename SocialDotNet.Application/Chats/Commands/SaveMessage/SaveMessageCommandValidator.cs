using FluentValidation;

namespace SocialDotNet.Application.Chats.Commands.SaveMessage
{
    public class SaveMessageCommandValidator : AbstractValidator<SaveMessageCommand>
    {
        public SaveMessageCommandValidator()
        {
            RuleFor(x => x.ChatId).NotEmpty();
            RuleFor(x => x.SenderId).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
