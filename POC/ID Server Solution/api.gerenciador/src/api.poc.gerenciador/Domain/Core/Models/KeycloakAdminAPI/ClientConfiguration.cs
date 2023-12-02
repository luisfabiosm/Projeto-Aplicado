using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{

    public record ClientConfiguration
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("clientId")]
        public string ClientId { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("rootUrl")]
        public string RootUrl { get; init; }

        [JsonPropertyName("baseUrl")]
        public string BaseUrl { get; init; }

        [JsonPropertyName("surrogateAuthRequired")]
        public bool SurrogateAuthRequired { get; init; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; }

        [JsonPropertyName("alwaysDisplayInConsole")]
        public bool AlwaysDisplayInConsole { get; init; }

        [JsonPropertyName("clientAuthenticatorType")]
        public string ClientAuthenticatorType { get; init; }

        [JsonPropertyName("redirectUris")]
        public List<string> RedirectUris { get; init; }

        [JsonPropertyName("webOrigins")]
        public List<string> WebOrigins { get; init; }

        [JsonPropertyName("notBefore")]
        public int NotBefore { get; init; }

        [JsonPropertyName("bearerOnly")]
        public bool BearerOnly { get; init; }

        [JsonPropertyName("consentRequired")]
        public bool ConsentRequired { get; init; }

        [JsonPropertyName("standardFlowEnabled")]
        public bool StandardFlowEnabled { get; init; }

        [JsonPropertyName("implicitFlowEnabled")]
        public bool ImplicitFlowEnabled { get; init; }

        [JsonPropertyName("directAccessGrantsEnabled")]
        public bool DirectAccessGrantsEnabled { get; init; }

        [JsonPropertyName("serviceAccountsEnabled")]
        public bool ServiceAccountsEnabled { get; init; }

        [JsonPropertyName("publicClient")]
        public bool PublicClient { get; init; }

        [JsonPropertyName("frontchannelLogout")]
        public bool FrontchannelLogout { get; init; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; init; }

        [JsonPropertyName("attributes")]
        public Dictionary<string, string> Attributes { get; init; }

        [JsonPropertyName("authenticationFlowBindingOverrides")]
        public Dictionary<string, string> AuthenticationFlowBindingOverrides { get; init; }

        [JsonPropertyName("fullScopeAllowed")]
        public bool FullScopeAllowed { get; init; }

        [JsonPropertyName("nodeReRegistrationTimeout")]
        public int NodeReRegistrationTimeout { get; init; }

        [JsonPropertyName("defaultClientScopes")]
        public List<string> DefaultClientScopes { get; init; }

        [JsonPropertyName("optionalClientScopes")]
        public List<string> OptionalClientScopes { get; init; }

        [JsonPropertyName("access")]
        public Access Access { get; init; }

        [JsonPropertyName("protocolMappers")]
        public List<ProtocolMapper> ProtocolMappers { get; init; }
    }

    public record Access
    {
        [JsonPropertyName("view")]
        public bool View { get; init; }

        [JsonPropertyName("configure")]
        public bool Configure { get; init; }

        [JsonPropertyName("manage")]
        public bool Manage { get; init; }
    }

    public record ProtocolMapper
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; init; }

        [JsonPropertyName("protocolMapper")]
        public string ProtocolMapperType { get; init; }

        [JsonPropertyName("consentRequired")]
        public bool ConsentRequired { get; init; }

        [JsonPropertyName("config")]
        public Dictionary<string, string> Config { get; init; }
    }
}