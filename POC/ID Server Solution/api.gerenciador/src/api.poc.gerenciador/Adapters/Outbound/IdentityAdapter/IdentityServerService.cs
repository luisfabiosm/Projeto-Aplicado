using Adapters.Outbound.IdentityAdapter.KeycloakPorts;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Outbound;
using Refit;

namespace Adapters.Outbound.IdentityAdapter
{
    public class IdentityServerService : IIdentityServerServicePort
    {
        private static string _authHeaders;
 
        private IIdentityConnection _connection;
        private readonly IKeycloakAdminAPIPort _keycloakApi;
        public IdentityServerService(IServiceProvider serviceProvider)
        {
            _connection = serviceProvider.GetRequiredService<IIdentityConnection>();
            _keycloakApi = _connection.Connection();

            var authHeaders = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer " },
            };

        }

        private string GetToken()
        {
           return _connection.GetAuthToken();
        }


        public async Task<string> CreateRealmAsync(CreateRealmRequest request)
        {
            
            try
            {
                _authHeaders = GetToken();
                var response = await _keycloakApi.CreateRealm(_authHeaders, request);

                return GetIdResponse(response.Headers.GetValues("Location").FirstOrDefault(), "realms/");
            }
            catch
            {
                throw;
            }
        }


        public async Task<string> CreateClientAsync(string realm, CreateClientRequest request)
        {
            try
            {
                _authHeaders = GetToken();
                var response = await _keycloakApi.CreateClient(realm, _authHeaders, request);

                return GetIdResponse(response.Headers.GetValues("Location").FirstOrDefault(), "clients/");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> CreateUserAsync(string realm, CreateUserRequest request)
        {
            try
            {
                _authHeaders = GetToken();
                var response = await _keycloakApi.CreateUsers(realm, _authHeaders, request);

                return GetIdResponse(response.Headers.GetValues("Location").FirstOrDefault(), "users/");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> CreateClientScopes(string realm, CreateClientScopesRequest request)
        {
            try
            {
                //create scope
                _authHeaders = GetToken();
                var response = await _keycloakApi.CreateClientScopes(realm, _authHeaders, request);
                var _id = GetIdResponse(response.Headers.GetValues("Location").FirstOrDefault(), "client-scopes/");

                //config as default
                return await ConfigClientScopeAsDefalut(realm, _id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> ConfigClientScopeAsDefalut(string realm, string clientid)
        {
            try
            {
                _authHeaders = GetToken();
                var response = await _keycloakApi.ConfigClientScopesAsDefault(realm, clientid, _authHeaders);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.StatusCode.ToString());

                return clientid;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<string> CreateProtocolMapperClientScope(string realm, string clientscopeId, string clientId, string mapperName, string clientName)
        {
            try
            {

                _authHeaders = GetToken();
                var _mapper = new ProtocolMapperRequest
                {
                    Name = mapperName,
                    Protocol = "openid-connect",
                    ProtocolMapper = "oidc-audience-mapper",
                    Config = new Dictionary<string, string>()
                    {
                        { "id.token.claim", "false" },
                        { "access.token.claim", "true" },
                        { "included.client.audience", $"{clientName}" },
                        { "included.custom.audience", $"" },
                    }
                };

                var response = await _keycloakApi.CreateProtocolMapperClientScope(realm, clientscopeId, _authHeaders, _mapper);

                var _id = GetIdResponse(response.Headers.GetValues("Location").FirstOrDefault(), "protocol-mappers/models/");
                return _id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> AddClientScopeAsDefaultToClient(string realm, string Id, string clientscopeId)
        {
            try
            {

                _authHeaders = GetToken();
                var response = await _keycloakApi.AddClientScopeAsDefaultToClient(realm, Id, clientscopeId, _authHeaders);

                return response.StatusCode.ToString(); ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> GetClientById(string realm, string Id)
        {
           try
            {
                _authHeaders = GetToken();
                var response = await _keycloakApi.GetClientInstallationById(realm, Id, _authHeaders);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<List<ClientConfiguration>> GetClients(string realm)
        {
            try
            {
                _authHeaders = GetToken();
                var response = await _keycloakApi.GetClients(realm, _authHeaders);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ClientConfiguration> GetClientByClienId(string realm, string clientId)
        {
            try
            {             
                _authHeaders = GetToken();
                var response = await _keycloakApi.GetClients(realm, _authHeaders);

                return response.FirstOrDefault(x => x.ClientId == clientId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<UserConfiguration>> GetUsers(string realm)
        {
            try
            {
                _authHeaders = GetToken();
                var response = await _keycloakApi.GetUsers(realm, _authHeaders);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<UserConfiguration> GetUsersByUsername(string realm, string username)
        {
            try
            {
                _authHeaders = GetToken();
                var queryParams = new Dictionary<string, string>
                {
                    {"username", username}
                };

                var response = await _keycloakApi.GetUserByUsername(realm, queryParams, _authHeaders);
                return response.FirstOrDefault(x => x.Username == username);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private string GetIdResponse(string location, string index)
        {
            return location.Substring(location.IndexOf(index) + index.Length);
        }

      
    }


}
