using Domain.Core.Models.KeycloakAdminAPI;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace Domain.Core.Models.Settings
{
    public record IdentityServerSettings
    {

        public string Endpoint { get; set; }
        public AccessTokenSettings AccessToken { get; set; }

        public IdentityServerSettings()
        {

        }
    }

    public record AccessTokenSettings
    {
        public string ClientId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string GrantType { get; set; }

        public AccessTokenSettings()
        {

        }

    }
}
