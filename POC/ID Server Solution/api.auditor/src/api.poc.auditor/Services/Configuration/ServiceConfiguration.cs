using Adapters.Inbound.Configuration;
using Adapters.Inbound.RestAdapters.Configuration;
using Adapters.Outbound.IdentityAdapter.Configuration;
using Adapters.Outbund.DBAdapter.Configuration;
using Domain.Core.Models.Settings;

namespace Services.Configuration
{
    public static class ServiceConfiguration
    {

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AppSettings appSettings = new();
            configuration.GetSection("AppSettings").Bind(appSettings);

            services.AddDatabase(appSettings.DBSettings);
            services.AddUseCases();
            services.AddRestEndpoints();


            return services;
        }
    }
}
