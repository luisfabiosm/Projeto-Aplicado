using Domain.Core.Models.Settings;
using Domain.Core.Ports.Inbound;
using Domain.UseCases.GetUserAuthorization;

namespace Adapters.Inbound.Configuration
{
    public static class UseCaseConfiguration
    {

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseGetUserAuthorization, UseCaseGetUserAuthorization>();

            return services;
        }
    }
}
