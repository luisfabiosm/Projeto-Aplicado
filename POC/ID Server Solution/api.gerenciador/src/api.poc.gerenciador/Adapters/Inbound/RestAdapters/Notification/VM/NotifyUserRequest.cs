namespace Adapters.Inbound.RestAdapters.Notification.VM
{
    public record NotifyUserRequest
    {
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string Username { get; set; }
    }
}
