namespace Domain.Core.Models.KeycloakAdminAPI
{

    public record OIDCInstalationToken
    {
        public string Realm { get; init; }
        public string AuthServerUrl { get; init; }
        public string SslRequired { get; init; }
        public string Resource { get; init; }
        public bool VerifyTokenAudience { get; init; }
        public ClientCredentials Credentials { get; init; }
        public int ConfidentialPort { get; init; }
    }

    public record ClientCredentials
    {
        public string Secret { get; init; }
    }
}
