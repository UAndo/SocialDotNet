using Microsoft.AspNetCore.Mvc.Infrastructure;
using SocialDotNet.Server.Common.Errors;
using SocialDotNet.Server.Common.Mapping;

namespace SocialDotNet.Server
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
