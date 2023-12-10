using Domain.Core.Models.Entities;
using Domain.Core.Models.KeycloakAdminAPI;
//using Domain.Core.Models.KeycloakAdminAPI;
//using Keycloak.Net.Models.Users;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Adapters.Inbound.RestAdapters.Notification.VM
{
    public record NotifyUserResponse
    {
        [JsonPropertyName("grant_type")]
        public string GrantType { get; internal set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; internal set; }

        [JsonPropertyName("username")]
        public string Username { get; internal set; }

        [JsonPropertyName("password")]
        public string Password { get; internal set; }

        [JsonPropertyName("secret")]
        public string Secret { get; internal set; }

        public NotifyUserResponse(User user, string secret)
        {
            var _token = JsonConvert.DeserializeObject<AccessToken>(user.identityuserinfo);


            this.GrantType = "password";
            this.Username = user.sysusername;
            this.ClientId = user.clientid;
            this.Password = user.syspassword;
            this.Secret = secret;

        }
    }



}
