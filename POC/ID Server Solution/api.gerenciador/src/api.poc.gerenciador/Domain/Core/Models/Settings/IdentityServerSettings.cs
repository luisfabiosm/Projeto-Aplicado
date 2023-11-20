using Domain.Core.Models.KeycloakAdminAPI;
using System.Diagnostics.Contracts;

namespace Domain.Core.Models.Settings
{
    public record IdentityServerSettings
    {  

        public string Endpoint { get; set; }
        public AccessTokenRequest AccessToken { get; set; }
    }
}
