using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialDotNet.Application.Common.Behavior;

namespace SocialDotNet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
