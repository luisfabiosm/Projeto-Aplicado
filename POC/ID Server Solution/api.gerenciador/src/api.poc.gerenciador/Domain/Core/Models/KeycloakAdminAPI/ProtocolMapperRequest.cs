using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record ProtocolMapperRequest
    {
        //[JsonPropertyName("id")]
        //public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; init; }

        [JsonPropertyName("protocolMapper")]
        public string ProtocolMapper { get; init; }

        [JsonPropertyName("consentRequired")]
        public bool consentRequired { get; init; }

        [JsonPropertyName("consentText")]
        public string ConsentText { get; init; }

        [JsonPropertyName("config")]
        public Dictionary<string, string> Config { get; init; } = new Dictionary<string, string>();


    }


    public record MapperConfig
    {


        [JsonPropertyName("id.token.claim")]
        public bool IdTokenClaim { get; init; }


        [JsonPropertyName("access.token.claim")]
        public bool AccessTokenClaim { get; init; }


        [JsonPropertyName("included.client.audience")]
        public string IncludedClientAudience { get; init; }


        [JsonPropertyName("included.custom.audience")]
        public string IncludedCustomAudience { get; init; } = "";
    }
}
