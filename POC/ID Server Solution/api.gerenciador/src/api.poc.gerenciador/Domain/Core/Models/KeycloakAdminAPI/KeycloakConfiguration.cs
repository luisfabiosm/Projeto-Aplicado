namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record KeycloakConfiguration
    {
        public string Realm { get; init; }
        public string AuthServerUrl { get; init; }
        public string SslRequired { get; init; }
        public string Resource { get; init; }
        public bool VerifyTokenAudience { get; init; }
        public ConfigCredentials Credentials { get; init; }
        public int ConfidentialPort { get; init; }
    }

    public record ConfigCredentials
    {
        public string Secret { get; init; }
    }
}
