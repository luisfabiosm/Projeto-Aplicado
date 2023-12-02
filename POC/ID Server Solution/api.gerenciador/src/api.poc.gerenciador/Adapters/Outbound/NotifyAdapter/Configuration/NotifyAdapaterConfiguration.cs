using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;

namespace Adapters.Outbound.NotifyAdapter.Configuration
{
    public static class NotifyAdapaterConfiguration
    {

        public static IServiceCollection AddNotifyAdapter(this IServiceCollection services, NotifySettings settings)
        {

            services.AddTransient<INotifyServicePort, NotifyServicePort>();

            return services;
        }
    }
}
