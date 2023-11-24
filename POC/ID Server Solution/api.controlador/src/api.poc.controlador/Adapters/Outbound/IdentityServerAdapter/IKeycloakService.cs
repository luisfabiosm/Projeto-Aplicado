using Domain.Core.Models.VO;
using Refit;

namespace Adapters.Outbound.IdentityServerAdapter
{
    public interface IKeycloakService
    {
        //[Post("/realms/poc/protocol/openid-connect/token")]
        //Task<TokenInfo> GetToken(string grant_type, string client_id, string username, string password, string client_secret);

        [Post("/realms/poc/protocol/openid-connect/token")]
        Task<TokenInfo> GetAccessTokenAsync(
        [AliasAs("grant_type")] string grantType,
        [AliasAs("client_id")] string clientId,
        [AliasAs("username")] string username,
        [AliasAs("password")] string password,
        [AliasAs("client_secret")] string clientSecret);
    }
}
