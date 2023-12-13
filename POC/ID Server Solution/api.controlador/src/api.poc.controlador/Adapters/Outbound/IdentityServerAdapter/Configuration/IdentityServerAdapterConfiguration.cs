using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;

namespace Adapters.Outbound.IdentityServerAdapter.Configuration
{
    public static class IdentityServerAdapterConfiguration
    {
        public static IServiceCollection AddIdentityServerAdapter(this IServiceCollection services, IdentityServerSettings settings)
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
