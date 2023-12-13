using Domain.Core.Models.Keycloak;
using Refit;

namespace Adapters.Outbound.IdentityServerAdapter.KeycloakPorts
{
    public interface IKeycloakAdminAPIPort
    {

        [Post("/realms/{realm}/protocol/openid-connect/token")]
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        Task<AccessToken> GetAccessToken(string realm, [Body(BodySerializationMethod.UrlEncoded)] AccessTokenRequest request);

    }
}
