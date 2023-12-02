using Domain.UseCases.ClientApplication.RegisterClientApp;
using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record CreateClientKeycloak : IDisposable
    {

        [JsonPropertyName("protocol")]
        public string Protocol { get; init; } = "openid-connect";

        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; } = true;

        [JsonPropertyName("publicClient")]
        public bool PublicClient { get; init; } = false;

        [JsonPropertyName("standardFlowEnabled")]
        public bool StandardFlowEnabled { get; init; } = true;

        [JsonPropertyName("serviceAccountsEnabled")]
        public bool ServiceAccountsEnabled { get; init; } = false;

        [JsonPropertyName("directAccessGrantsEnabled")]
        public bool DirectAccessGrantsEnabled { get; init; } = true;

        [JsonPropertyName("attributes")]
        public Dictionary<string, bool> Attributes { get; init; } = new Dictionary<string, bool>()
        {
            //{ "oauth2.device.authorization.grant.enabled", true }
        };

        public CreateClientKeycloak(TransactionRegisterClient transaction)
        {
            ClientId = transaction.ClientInfo.ClientId;
            Name = transaction.ClientInfo.ClientName;
            Description = $"Client para aplicações: {transaction.ClientInfo.ClientName}";
        }

        public void Dispose()
        {

        }
    }
}
