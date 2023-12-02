using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record CreateRealmRequest : IDisposable
    {
        [JsonPropertyName("realm")]
        public string Realm { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; } = true;

        public CreateRealmRequest(string realm)
        {
            this.Realm = realm;
        }

        public void Dispose()
        {
            this.Realm = null;
        }
    }
}
