using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;

namespace Adapters.Outbound.IdentityAdapter.Configuration
{
    public static class IdentityAdapterConfiguration
    {

        public static IServiceCollection AddIdentityServer(this IServiceCollection services, IdentityServerSettings settings)
        {

            services.AddSingleton<IIdentityConnection>(options =>
            {
                return new IdentityConnection(settings);
            });

            services.AddSingleton<IIdentityServerServicePort, IdentityServerService>();

            return services;
        }

    }
}
