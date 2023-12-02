using Domain.Core.Models.Keycloak;
using Domain.Core.Models.KeycloakAdminAPI;
using Refit;

namespace Adapters.Outbound.IdentityAdapter.KeycloakPorts
{
    public interface IKeycloakAdminAPIPort
    {

        [Post("/realms/{realm}/protocol/openid-connect/token")]
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        Task<AccessToken> GetAccessToken(string realm, [Body(BodySerializationMethod.UrlEncoded)] AccessTokenRequest request);

    }
}
