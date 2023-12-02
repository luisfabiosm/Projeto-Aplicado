using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record AccessToken
    {

        private DateTime _expirationDate;

        [JsonPropertyName("access_token")]
        public string access_token { get; set; }

        [JsonPropertyName("expires_in")]
        public int expires_in { get; set; }

        [JsonPropertyName("scope")]
        public string scope { get; set; }

        [JsonPropertyName("refresh_token")]
        public string refresh_token { get; set; }

        [JsonPropertyName("refresh_expires_in")]
        public int refresh_expires_in { get; set; }

        [JsonIgnore]
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
        }



        public void NewExpirationDate()
        {
            this._expirationDate.AddMilliseconds(expires_in);
        }

        public AccessToken()
        {

        }
    }
}
