using Domain.Core.Models.Settings;
using Domain.Core.Ports.Inbound;
using Domain.UseCases.GetAuthorization;

namespace Adapters.Inbound.Configuration
{
    public static class UseCaseConfiguration
    {

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseGetAuthorization, UseCaseGetAuthorization>();

            return services;
        }
    }
}
