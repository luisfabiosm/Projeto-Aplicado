using Adapters.Outbound.IdentityAdapter.KeycloakPorts;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;
using Refit;

namespace Adapters.Outbound.IdentityAdapter
{
    public class IdentityConnection : IIdentityConnection
    {
        private readonly IKeycloakAdminAPIPort _keycloakApi;
        private IdentityServerSettings _settings;
        internal static Domain.Core.Models.KeycloakAdminAPI.AccessToken _validToken = null;


        public IdentityConnection(IdentityServerSettings settings)
        {
            _settings = settings;
            _keycloakApi = RestService.For<IKeycloakAdminAPIPort>(settings.Endpoint);
        }

        public IKeycloakAdminAPIPort Connection()
        {
            return _keycloakApi;
        }

        public string GetAuthToken(string realm = "")
        {
            //if ((_validToken is not null) && ((DateTime.Now - _validToken.ExpirationDate).TotalSeconds >= 0))
            //    return _validToken.access_token;

            var _requestToken = new AccessTokenRequest
            {
                Username = _settings.AccessToken.Username ?? "",
                Password = _settings.AccessToken.Password ?? "",
                ClientId = _settings.AccessToken.ClientId ?? "",
                GrantType = _settings.AccessToken.GrantType ?? ""
            };

            _validToken = _keycloakApi.GetAccessToken(string.IsNullOrEmpty(realm) ? _settings.Realm : realm, _requestToken).Result;
            //_validToken = _keycloakApi.GetAccessToken("master", _requestToken).Result;

            return _validToken.access_token;
        }
    }
}
