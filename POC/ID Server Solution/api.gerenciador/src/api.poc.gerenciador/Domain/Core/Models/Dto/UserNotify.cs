using System.Text.Json.Serialization;

namespace Domain.Core.Models.Dto
{
    public record UserNotify
    {
        [JsonPropertyName("user")]
        public string User { get; internal set; }

        [JsonPropertyName("secret")]
        public string Secret { get; internal set; }


        public UserNotify()
        {

        }
        public UserNotify(string user, string secret)
        {
            this.User = user;
            this.Secret = secret;
        }

    }
}
