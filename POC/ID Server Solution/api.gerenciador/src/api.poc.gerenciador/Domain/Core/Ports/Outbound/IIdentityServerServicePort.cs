
using Domain.Core.Models.KeycloakAdminAPI;

namespace Domain.Core.Ports.Outbound
{
    public interface IIdentityServerServicePort
    {
        Task<string> GetToken(string realm, string clientid, string username, string password);

        Task<string> CreateRealmAsync(CreateRealmRequest request);


        Task<string> CreateClientAsync(string realm, CreateClientKeycloak request);


        Task<string> CreateUserAsync(string realm, CreateUserKeycloak request);


        Task<string> CreateClientScopes(string realm, CreateClientScopesRequest request);


        Task<string> ConfigClientScopeAsDefalut(string realm, string clientid);


        Task<string> CreateProtocolMapperClientScope(string realm, string clientscopeId, string clientId, string mapperName, string clientName);


        Task<string> AddClientScopeAsDefaultToClient(string realm, string Id, string clientscopeId);


        Task<string> GetClientById(string realm, string Id);


        Task<List<ClientConfiguration>> GetClients(string realm);


        Task<ClientConfiguration> GetClientByClienId(string realm, string clientId);


        Task<List<UserConfiguration>> GetUsers(string realm);


        Task<UserConfiguration> GetUsersByUsername(string realm, string username);

        Task<UserRepresentation> GetUsersById(string realm, string Id);

    }
}
