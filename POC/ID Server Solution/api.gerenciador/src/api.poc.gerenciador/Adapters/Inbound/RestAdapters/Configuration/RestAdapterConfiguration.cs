﻿

using Adapters.Inbound.RestAdapters.ClientApplication.Routes;
using Adapters.Inbound.RestAdapters.Notification.Route;
using Adapters.Inbound.RestAdapters.SecurityDomain.Routes;
using Adapters.Inbound.RestAdapters.Users.Routes;

namespace Adapters.Inbound.RestAdapters.Configuration
{
    public static class RestAdapterConfiguration
    {
        public static IServiceCollection AddRestEndpoints(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static void UseAPIExtensions(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Development" || app.Environment.EnvironmentName == "Local" || app.Environment.EnvironmentName == "Fabrica")
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            //Endpoints
            app.AddSecurityDomainEndpoint();

            app.AddGetUserEndpoint();
            app.AddCreateUserEndpoint();
            app.AddNotifyUsersEndpoint();
            app.AddListUsersEndpoint();

            app.AddRegisterClientApplicationEndpoint();
            app.AddGetClientApplicationEndpoint();
            app.AddListClientsApplicationEndpoint();
            app.AddNotifyClientEndpoint();


        }
    }

}

