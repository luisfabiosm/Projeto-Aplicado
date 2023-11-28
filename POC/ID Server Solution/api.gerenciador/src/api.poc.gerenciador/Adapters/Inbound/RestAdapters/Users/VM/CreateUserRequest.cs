using Domain.Core.Models.KeycloakAdminAPI;
using System.Text.Json.Serialization;

namespace Adapters.Inbound.RestAdapters.Users.VM
{
    public record CreateUserRequest
    {
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }

    }
}
