using Domain.Core.Models.KeycloakAdminAPI;
using System.Text.Json.Serialization;

namespace Adapters.Inbound.RestAdapters.Users.VM
{
    public record UserResponse
    {
        public string Id { get; init; }
        public string Username { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }

    }
}
