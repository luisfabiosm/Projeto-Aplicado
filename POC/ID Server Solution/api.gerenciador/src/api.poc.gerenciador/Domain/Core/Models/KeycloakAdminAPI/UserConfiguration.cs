using System.Text.Json.Serialization;
namespace Domain.Core.Models.KeycloakAdminAPI
{



    public record UserConfiguration
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("createdTimestamp")]
        public long CreatedTimestamp { get; init; }

        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; }

        [JsonPropertyName("totp")]
        public bool Totp { get; init; }

        [JsonPropertyName("emailVerified")]
        public bool EmailVerified { get; init; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; init; }

        [JsonPropertyName("lastName")]
        public string LastName { get; init; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("disableableCredentialTypes")]
        public string[] DisableableCredentialTypes { get; init; }

        [JsonPropertyName("requiredActions")]
        public string[] RequiredActions { get; init; }

        [JsonPropertyName("federatedIdentities")]
        public FederatedIdentity[] FederatedIdentities { get; init; }

        [JsonPropertyName("notBefore")]
        public int NotBefore { get; init; }

        [JsonPropertyName("access")]
        public AccessUser Access { get; init; }
    }

    public record FederatedIdentity
    {
        [JsonPropertyName("identityProvider")]
        public string IdentityProvider { get; init; }

        [JsonPropertyName("userId")]
        public string UserId { get; init; }

        [JsonPropertyName("userName")]
        public string UserName { get; init; }
    }

    public record AccessUser
    {
        [JsonPropertyName("manageGroupMembership")]
        public bool ManageGroupMembership { get; init; }

        [JsonPropertyName("view")]
        public bool View { get; init; }

        [JsonPropertyName("mapRoles")]
        public bool MapRoles { get; init; }

        [JsonPropertyName("impersonate")]
        public bool Impersonate { get; init; }

        [JsonPropertyName("manage")]
        public bool Manage { get; init; }
    }

}
