using System.Text.Json.Serialization;

namespace Domain.Core.Models.Dto
{
  
    public record ClientNotify 
    {
        public string Realm { get; init; }

        [JsonPropertyName("auth-server-url")]
        public string AuthServerUrl { get; init; }

        [JsonPropertyName("ssl-required")]
        public string SslRequired { get; init; }

        public string Resource { get; init; }

        [JsonPropertyName("verify-token-audience")]
        public bool VerifyTokenAudience { get; init; }

        public Credentials Credentials { get; init; }

        [JsonPropertyName("confidential-port")]
        public int ConfidentialPort { get; init; }

    }

    public record Credentials
    {
        public string Secret { get; init; }
    }

}
