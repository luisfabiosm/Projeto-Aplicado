using System.Text.Json.Serialization;

namespace Adapters.Inbound.RestAdapters.Users.VM
{
    public record NotifyUserResponse
    {
        public DateTime NotificationDate { get; set; }
        public string NotificationId { get; set; }
    }
}
