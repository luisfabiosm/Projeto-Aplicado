using Adapters.Outbund.DBAdapter;
using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;

namespace Adapters.Outbund.DBAdapter.Configuration
{
    public static class DBAdapterConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, ConnectionSettings settings)
        {
            //Connection

            #region PostgreSQL Session Management

            services.AddSingleton<IDBConnection>(options =>
            {
                return new DBConnection(settings);
            });

            services.AddTransient<IDBRepositoryPort, DBRepository>();

            return services;

            #endregion
        }
    }
}
