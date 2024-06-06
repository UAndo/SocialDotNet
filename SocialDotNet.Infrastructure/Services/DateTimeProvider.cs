using SocialDotNet.Application.Common.Interfaces.Services;

namespace SocialDotNet.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}