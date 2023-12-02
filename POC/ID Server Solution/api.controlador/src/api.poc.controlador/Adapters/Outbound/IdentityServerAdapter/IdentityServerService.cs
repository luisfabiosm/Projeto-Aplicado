using Adapters.Outbound.IdentityAdapter.KeycloakPorts;
using Domain.Core.Models.Entities;
using Domain.Core.Models.Keycloak;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Outbound;

namespace Adapters.Outbound.IdentityServerAdapter
{
    public class IdentityServerService : IIdentityServerServicePort
    {
        private static string _adminAuthHeaders;

        private IIdentityConnection _connection;
        private readonly IKeycloakAdminAPIPort _keycloakApi;
        public IdentityServerService(IServiceProvider serviceProvider)
        {
            _connection = serviceProvider.GetRequiredService<IIdentityConnection>();
            _keycloakApi = _connection.Connection();

        }

        public async Task<AccessToken> GetAuthToken(AuthCredentials credentials)
        {
            var _accessRequest = new AccessTokenRequest
            {
                ClientId = credentials.ClientId,
                Username = credentials.Username,
                Password = credentials.Password,
                GrantType = credentials.GrantType
            };

            return await _keycloakApi.GetAccessToken(credentials.Realm, _accessRequest);//, credentials.Secret);
        }



    }
}
