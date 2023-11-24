using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
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

 
    }
}
