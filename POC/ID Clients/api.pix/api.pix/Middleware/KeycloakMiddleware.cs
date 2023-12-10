using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;

namespace Middleware
{
    public static class KeycloakMiddleware
    {

        public static IServiceCollection AddKeycloakIDAuth(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
        {

            var authenticationOptions = builder
                              .Configuration
                              .GetSection(KeycloakAuthenticationOptions.Section)
                              .Get<KeycloakAuthenticationOptions>();

            builder.Services.AddKeycloakAuthentication(authenticationOptions);

            var authorizationOptions = builder
                                        .Configuration
                                        .GetSection(KeycloakProtectionClientOptions.Section)
                                        .Get<KeycloakProtectionClientOptions>();

            builder.Services.AddKeycloakAuthorization(authorizationOptions);

            var adminClientOptions = builder
                             .Configuration
                             .GetSection(KeycloakAdminClientOptions.Section)
                             .Get<KeycloakAdminClientOptions>();

            builder.Services.AddKeycloakAdminHttpClient(adminClientOptions);

            return services;
        }
    }
}
