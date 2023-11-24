namespace Adapters.Inbound.RestAdapters.ClientApplication.VM
{
    public record RegisterClientRequest
    {
        public string Realm { get; set; }
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }

    }
}
