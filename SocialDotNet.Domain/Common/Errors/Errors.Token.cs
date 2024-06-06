using ErrorOr;

namespace SocialDotNet.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Token
        {
            public static Error InvalidToken => Error.Unauthorized(
                code: "Token.InvalidToken",
                description: "Invalid Token."
            );
        }
    }
}
