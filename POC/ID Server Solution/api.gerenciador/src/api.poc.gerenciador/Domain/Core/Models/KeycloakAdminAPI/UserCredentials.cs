using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record UserCredentials
    {

        [JsonPropertyName("createdDate")]
        public long CreatedDate { get; init; } = DateTime.UtcNow.Ticks;

        [JsonPropertyName("userLabel")]
        public string UserLabel { get; init; } = "My Password";

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("value")]
        public string Value { get; init; }

        [JsonPropertyName("temporary")]
        public bool Temporary { get; init; } = false;
    }
}
