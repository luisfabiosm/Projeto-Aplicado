using Refit;
using TesteKeycloak.net.Models;

namespace TesteKeycloak.net.Interfaces
{
    public interface IKeycloakAPIService
    {

        [Get("/realms/master/protocol/openid-connect/token")]
        Task<AccessTokenResponse> GetAccessTokenAsync(AccessTokenRequest request);

        //[Get("/admin/realms/{realm}/clients")]
        //Task<Client[]> GetClientsAsync(string realm, [Header("Authorization")] string accessToken);

        //[Post("/users")]
        //Task<User> CreateUser([Body] User user);



    }
}
