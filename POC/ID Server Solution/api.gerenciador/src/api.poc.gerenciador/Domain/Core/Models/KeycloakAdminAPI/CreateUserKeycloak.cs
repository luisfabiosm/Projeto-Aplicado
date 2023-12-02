using Domain.UseCases.Users.CreateUser;
using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record CreateUserKeycloak : IDisposable
    {
        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; } = true;

        [JsonPropertyName("credentials")]
        public UserCredentials[] Credentials { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; init; }

        [JsonPropertyName("lastName")]
        public string LastName { get; init; }

        public CreateUserKeycloak()
        {

        }

        public CreateUserKeycloak(TransactionCreateUser transaction)
        {
            Username = transaction.UserInfo.Username;
            Email = transaction.UserInfo.Email;
            FirstName = transaction.UserInfo.FirstName;
            LastName = transaction.UserInfo.LastName;

            Credentials = new UserCredentials[1];
            Credentials[0] = transaction.UserInfo.Credentials[0];

        }

        public void Dispose()
        {
            Array.Clear(this.Credentials);

        }
    }
}
