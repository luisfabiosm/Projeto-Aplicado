using Refit;
using TesteKeycloak.net.Interfaces;
using TesteKeycloak.net.Models;

namespace TesteKeycloak.net.Services
{
    public class KeycloakAPIService : IKeycloakAPIService
    {
        private readonly string _serverUrl = "https://localhost:8089";// auth/admin/master";
        private Dictionary<string, string> _authHeaders;

        public KeycloakAPIService()
        {
            var authHeaders = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer " },
            };
        }

        public async Task<AccessTokenResponse> GetAccessTokenAsync(AccessTokenRequest accessTokenRequest)
        {
            var _keycloakApi = RestService.For<IKeycloakAPIClient>(_serverUrl);
            try
            {
                var accessTokenResponse = await _keycloakApi.GetAccessToken(accessTokenRequest);


                Console.WriteLine($"Access token: {accessTokenResponse.AccessToken}...");
                Console.WriteLine($"Expires in: {accessTokenResponse.ExpiresIn}s");

                _authHeaders = new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {accessTokenResponse.AccessToken}" },
                };

                return accessTokenResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
