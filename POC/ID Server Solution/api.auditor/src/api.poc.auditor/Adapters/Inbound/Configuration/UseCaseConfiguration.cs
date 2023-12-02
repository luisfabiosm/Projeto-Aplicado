using Domain.Core.Ports.Inbound;
using Domain.UseCases.GetLogById;
using Domain.UseCases.ListLogsByFilter;



namespace Adapters.Inbound.Configuration
{
    public static class UseCaseConfiguration
    {

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseListLogsPort, UseCaseListLogs>();
            services.AddScoped<IUseCaseGetLogPort, UseCaseGetLog>();


            return services;
        }
    }
}
