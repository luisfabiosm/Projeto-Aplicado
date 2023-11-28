using Adapters.Outbound.IdentityAdapter.KeycloakPorts;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Outbound;
using Domain.UseCases.Users.CreateUser;
using Keycloak.Net.Models.RealmsAdmin;
using Keycloak.Net.Models.Root;
using Refit;
using System;

namespace Adapters.Outbound.IdentityAdapter
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

            var authHeaders = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer " },
            };

        }

        private string GetToken(string realm = "")
        {
           return "Bearer " + _connection.GetAuthToken(realm);
        }


        public async Task<string> CreateRealmAsync(CreateRealmRequest request)
        {
            
            try
            {
                _adminAuthHeaders = GetToken("");
                var response = await _keycloakApi.CreateRealm(_adminAuthHeaders, request);

                //create admin user  for Token
                var _credentials = new UserCredentials
                {
                    Value = "admin",
                    Type = "Password",
                    UserLabel = "My Password"
                };


                _adminAuthHeaders = GetToken("master");// request.Realm);

                var _newUser = new CreateUserKeycloak
                {
                    
                    Username = "admin",
                    FirstName = "admin user",
                    Credentials = new UserCredentials[1] { _credentials },
                };


                var _response = await _keycloakApi.CreateUsers(request.Realm, _adminAuthHeaders, _newUser);

                return GetIdResponse(response.Headers.GetValues("Location").FirstOrDefault(), "realms/");
            }
            catch
            {
                throw;
            }
        }


        public async Task<string> CreateClientAsync(string realm, CreateClientKeycloak request)
        {
            try
            {

                //1 -  Gerar token
                _adminAuthHeaders = GetToken();

                //2 criar client
                var response = await _keycloakApi.CreateClient(realm, _adminAuthHeaders, request);
                return  GetIdResponse(response.Headers.GetValues("Location").FirstOrDefault(), "clients/");

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> CreateUserAsync(string realm, CreateUserKeycloak request)
        {
            try
            {
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.CreateUsers(realm, _adminAuthHeaders, request);

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
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.CreateClientScopes(realm, _adminAuthHeaders, request);
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
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.ConfigClientScopesAsDefault(realm, clientid, _adminAuthHeaders);

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

                _adminAuthHeaders = GetToken();
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

                var response = await _keycloakApi.CreateProtocolMapperClientScope(realm, clientscopeId, _adminAuthHeaders, _mapper);

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

                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.AddClientScopeAsDefaultToClient(realm, Id, clientscopeId, _adminAuthHeaders);

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
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.GetClientInstallationById(realm, Id, _adminAuthHeaders);

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
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.GetClients(realm, _adminAuthHeaders);

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
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.GetClients(realm, _adminAuthHeaders);

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
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.GetUsers(realm, _adminAuthHeaders);

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
                _adminAuthHeaders = GetToken();
                var queryParams = new Dictionary<string, string>
                {
                    {"username", username}
                };

                var response = await _keycloakApi.GetUserByUsername(realm, queryParams, _adminAuthHeaders);
                return response.FirstOrDefault(x => x.Username == username);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<UserRepresentation> GetUsersById(string realm, string Id)
        {
            try
            {
                _adminAuthHeaders = GetToken();
                var response = await _keycloakApi.GetUserById(realm, Id, _adminAuthHeaders);
                return response;
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

        public async Task<string> GetToken(string realm, string clientid, string username, string password)
        {

            var _requestToken = new AccessTokenRequest
            {
                Username = username,
                Password = username,
                ClientId = clientid,
                GrantType = "password"
            };

            var _validToken = _keycloakApi.GetAccessToken(realm, _requestToken).Result;

          return  $"Bearer {_validToken.access_token}";
        
        }
    }


}
