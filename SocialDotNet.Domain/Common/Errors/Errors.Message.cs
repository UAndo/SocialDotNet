using ErrorOr;

namespace SocialDotNet.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Message
        {
            public static Error InvalidRecipient => Error.Validation(
                code: "Message.InvalidRecipient",
                description: "Invalid recipient."
            );
        }
    }
}
