using System.Text.Json.Serialization;

namespace Adapters.Inbound.RestAdapters.Users.VM
{
    public record NotifyUserRequest
    {
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string Username { get; set; }
    }
}
