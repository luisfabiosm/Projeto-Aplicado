using Domain.Core.Ports.Inbound;
using Domain.UseCases.Clients.GetClient;
using Domain.UseCases.Clients.NotifyClient;
using Domain.UseCases.Clients.RegisterClient;
using Domain.UseCases.Users.AddUser;
using Domain.UseCases.Users.GetUser;
using Domain.UseCases.Users.NotifyUser;

namespace Adapters.Inbound.Configuration
{
    public static class UseCaseConfiguration
    {

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseCreateUserPort, UseCaseCreateUser>();
            services.AddScoped<IUseCaseRegisterClientPort, UseCaseRegisterClient>();
            services.AddScoped<IUseCaseGetUserPort, UseCaseGetUser>();
            services.AddScoped<IUseCaseGetClientPort, UseCaseGetClient>();
            services.AddScoped<IUseCaseNotifyUserPort, UseCaseNotifyUser>();
            services.AddScoped<IUseCaseNotifyClientPort, UseCaseNotifyClient>();
      
            return services;
        }
    }
}
