using System.Text.Json.Serialization;

namespace Adapters.Inbound.RestAdapters.Notification.VM
{
    public record NotifyClientRequest
    {
        public string Realm { get; set; }
        public string ClientId { get; set; }
  
    }
}
