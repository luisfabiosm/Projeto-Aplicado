using System.Text.Json.Serialization;

namespace Domain.Core.Models.Keycloak
{
    public record AccessTokenRequest
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }

        [JsonPropertyName("client_secret")]
        public string Secret { get; set; }

        public AccessTokenRequest()
        {

        }


    }
}
