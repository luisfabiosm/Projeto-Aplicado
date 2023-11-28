using Domain.Core.Models.KeycloakAdminAPI;
using Refit;

namespace Adapters.Outbound.IdentityAdapter.KeycloakPorts
{
    public interface IKeycloakAdminAPIPort
    {

        [Post("/realms/{realm}/protocol/openid-connect/token")]
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        Task<AccessToken> GetAccessToken(string realm, [Body(BodySerializationMethod.UrlEncoded)] AccessTokenRequest request);


        [Post("/admin/realms")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> CreateRealm([Header("Authorization")] string bearerToken, CreateRealmRequest request);


        [Post("/admin/realms/{realm}/clients")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> CreateClient(string realm, [Header("Authorization")] string bearerToken, CreateClientKeycloak request);


        [Post("/admin/realms/{realm}/users")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> CreateUsers(string realm, [Header("Authorization")] string bearerToken, CreateUserKeycloak request);


        [Post("/admin/realms/{realm}/client-scopes")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> CreateClientScopes(string realm, [Header("Authorization")] string bearerToken, CreateClientScopesRequest request);


        [Put("/admin/realms/{realm}/default-default-client-scopes/{clientScopeId}")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> ConfigClientScopesAsDefault(string realm, string clientScopeId, [Header("Authorization")] string bearerToken);


        [Post("/admin/realms/{realm}/client-scopes/{clientscopeId}/protocol-mappers/models")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> CreateProtocolMapperClientScope(string realm, string clientscopeId, [Header("Authorization")] string bearerToken, ProtocolMapperRequest request);


        [Put("/admin/realms/{realm}/clients/{Id}/default-client-scopes/{clientScopeId}")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> AddClientScopeAsDefaultToClient(string realm, string Id, string clientscopeId, [Header("Authorization")] string bearerToken);


        [Get("/admin/realms/{realm}/clients/{Id}")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> GetClientById(string realm, string Id, [Header("Authorization")] string bearerToken);


        [Get("/admin/realms/{realm}/clients/{id}/installation/providers/keycloak-oidc-keycloak-json")]
        [Headers("Content-Type: application/json")]
        Task<string> GetClientInstallationById(string realm, string Id, [Header("Authorization")] string bearerToken);


        [Get("/admin/realms/{realm}/clients")]
        [Headers("Content-Type: application/json")]
        Task<List<ClientConfiguration>> GetClients(string realm, [Header("Authorization")] string bearerToken);


        [Get("/admin/realms/{realm}/users")]
        [Headers("Content-Type: application/json")]
        Task<List<UserConfiguration>> GetUsers(string realm, [Header("Authorization")] string bearerToken);


        [Get("/admin/realms/{realm}/users")]
        [Headers("Content-Type: application/json")]
        Task<List<UserConfiguration>> GetUserByUsername(string realm, Dictionary<string, string> queryParams, [Header("Authorization")] string bearerToken);

        [Get("/admin/realms/{realm}/users/{Id}")]
        [Headers("Content-Type: application/json")]
        Task<UserRepresentation> GetUserById(string realm, string Id, [Header("Authorization")] string bearerToken);


    }
}
