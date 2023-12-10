
using Newtonsoft.Json;

namespace Domain.Core.Models.KeycloakAdminAPI
{

    public record OIDCInstalationToken
    {
        [JsonProperty("realm")]
        public string realm { get; set; }

        [JsonProperty("auth-server-url")]
        public string AuthServerUrl { get; set; }

        [JsonProperty("ssl-required")]
        public string SslRequired { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("verify-token-audience")]
        public bool VerifyTokenAudience { get; set; }

        [JsonProperty("credentials")]
        public ClientCredentials Credentials { get; set; }

        [JsonProperty("confidential-port")]
        public int ConfidentialPort { get; set; }

        public OIDCInstalationToken()
        {
            
        }
    }

    public record ClientCredentials
    {
        [JsonProperty("secret")]
        public string Secret { get; init; }
    }
}
