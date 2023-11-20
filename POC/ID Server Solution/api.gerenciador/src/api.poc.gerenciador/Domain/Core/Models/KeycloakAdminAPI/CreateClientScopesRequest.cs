using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record CreateClientScopesRequest
    {
        //[JsonIgnore]
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("attributes")]
        //public string[] Attributes { get; init; }
        public Dictionary<string, string> Attributes { get; init; } = new Dictionary<string, string>();

        [JsonPropertyName("protocolMappers")]
        public ProtocolMapperRequest[] Mappers { get; init; }
    }
}
