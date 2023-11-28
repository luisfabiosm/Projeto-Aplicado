namespace Domain.Core.Models.KeycloakAdminAPI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public record UserRepresentation
    {
        [JsonProperty("self")]
        public string Self { get; init; }

        [JsonProperty("id")]
        public string Id { get; init; }

        [JsonProperty("origin")]
        public string Origin { get; init; }

        [JsonProperty("createdTimestamp")]
        public long? CreatedTimestamp { get; init; }

        [JsonProperty("username")]
        public string Username { get; init; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; init; }

        [JsonProperty("totp")]
        public bool? Totp { get; init; }

        [JsonProperty("emailVerified")]
        public bool? EmailVerified { get; init; }

        [JsonProperty("firstName")]
        public string FirstName { get; init; }

        [JsonProperty("lastName")]
        public string LastName { get; init; }

        [JsonProperty("email")]
        public string Email { get; init; }

        [JsonProperty("federationLink")]
        public string FederationLink { get; init; }

        [JsonProperty("serviceAccountClientId")]
        public string ServiceAccountClientId { get; init; }

        [JsonProperty("attributes")]
        public Dictionary<string, List<string>> Attributes { get; init; }

        [JsonProperty("disableableCredentialTypes")]
        public HashSet<string> DisableableCredentialTypes { get; init; }

        [JsonProperty("requiredActions")]
        public List<string> RequiredActions { get; init; }

       [JsonProperty("realmRoles")]
        public List<string> RealmRoles { get; init; }

        [JsonProperty("clientRoles")]
        public Dictionary<string, List<string>> ClientRoles { get; init; }
    
        [JsonProperty("notBefore")]
        public int? NotBefore { get; init; }

        [JsonProperty("applicationRoles")]
        public Dictionary<string, List<string>> ApplicationRoles { get; init; }

       
        [JsonProperty("groups")]
        public List<string> Groups { get; init; }

        [JsonProperty("access")]
        public Dictionary<string, bool> Access { get; init; }

        [JsonProperty("userProfileMetadata")]
        public UserProfileMetadata UserProfileMetadata { get; init; }
    }

    
    public record UserProfileMetadata
    {
        [JsonProperty("realFirstName")]
        public string RealFirstName { get; init; }

        [JsonProperty("realLastName")]
        public string RealLastName { get; init; }
    }

}
