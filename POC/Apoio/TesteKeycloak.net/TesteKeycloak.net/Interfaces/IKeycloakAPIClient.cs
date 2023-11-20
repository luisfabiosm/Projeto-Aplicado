using Refit;
using TesteKeycloak.net.Models;

namespace TesteKeycloak.net.Interfaces
{
    public interface IKeycloakAPIClient
    {
        [Post("/realms/master/protocol/openid-connect/token")]
        Task<AccessTokenResponse> GetAccessToken([Body] AccessTokenRequest request);
    }
}
