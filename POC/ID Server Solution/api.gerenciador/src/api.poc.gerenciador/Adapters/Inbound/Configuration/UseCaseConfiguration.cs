using Domain.Core.Ports.Inbound;
using Domain.UseCases.ClientApplication.GetClientApp;
using Domain.UseCases.ClientApplication.ListClientsApp;
using Domain.UseCases.ClientApplication.NotifyClientApp;
using Domain.UseCases.ClientApplication.RegisterClientApp;
using Domain.UseCases.SecurityDomain.AddSecurityDomain;
using Domain.UseCases.Users.CreateUser;
using Domain.UseCases.Users.GetUser;
using Domain.UseCases.Users.ListUsers;
using Domain.UseCases.Users.NotifyUser;

namespace Adapters.Inbound.Configuration
{
    public static class UseCaseConfiguration
    {

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseCreateUserPort, UseCaseCreateUser>();
            services.AddScoped<IUseCaseNotifyUserPort, UseCaseNotifyUser>();
            services.AddScoped<IUseCaseGetUserPort, UseCaseGetUser>();
            services.AddScoped<IUseCaseListUsersPort, UseCaseListUsers>();

            services.AddScoped<IUseCaseRegisterClientPort, UseCaseRegisterClient>();
            services.AddScoped<IUseCaseGetClientPort, UseCaseGetClient>();
            services.AddScoped<IUseCaseNotifyClientPort, UseCaseNotifyClient>();
            services.AddScoped<IUseCaseListClientsAppPort, UseCaseListClientsApp>();

            services.AddScoped<IUseCaseAddSecurityDomainPort, UseCaseAddSecurityDomain>();

            return services;
        }
    }
}
