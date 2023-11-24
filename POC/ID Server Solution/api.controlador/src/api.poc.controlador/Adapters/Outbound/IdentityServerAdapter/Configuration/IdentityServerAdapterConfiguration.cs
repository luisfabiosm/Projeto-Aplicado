using Adapters.Outbound.DBAdapter;
using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;

namespace Adapters.Outbound.IdentityServerAdapter.Configuration
{
    public static class IdentityServerAdapterConfiguration
    {
        public static IServiceCollection AddIdentityServerAdapter(this IServiceCollection services, IdentityServerSettings settings)
        {
            

            services.AddTransient<IIdentityServerServicePort, IdentityServerService>();

            return services;
        }
    }
}
