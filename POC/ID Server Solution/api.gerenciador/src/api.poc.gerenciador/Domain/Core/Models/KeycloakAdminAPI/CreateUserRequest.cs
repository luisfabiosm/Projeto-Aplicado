using Domain.UseCases.ClientApplication.RegisterClientApp;
using Domain.UseCases.Users.CreateUser;
using Keycloak.Net.Models.Root;
using System.Text.Json.Serialization;

namespace Domain.Core.Models.KeycloakAdminAPI
{
    public record CreateUserRequest : IDisposable
    {
        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; } = true;

        [JsonPropertyName("credentials")]
        public UserCredentials[] Credentials { get; init; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; init; }

        [JsonPropertyName("lastName")]
        public string LastName { get; init; }


        public CreateUserRequest(TransactionCreateUser transaction)
        {
            Username = transaction.UserInfo.Username;
            Email = transaction.UserInfo.Email;
            FirstName = transaction.UserInfo.FirstName;
            LastName = transaction.UserInfo.LastName;

            for (int i = 0; i < transaction.UserInfo.Credentials.Length; i++)
            {
                Credentials[i] = transaction.UserInfo.Credentials[i];
            }
            
        }

        public void Dispose()
        {
            Array.Clear(this.Credentials);

        }
    }
}
