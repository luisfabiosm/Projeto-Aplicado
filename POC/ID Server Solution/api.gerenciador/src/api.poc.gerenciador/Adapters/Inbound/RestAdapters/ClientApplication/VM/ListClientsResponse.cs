namespace Adapters.Inbound.RestAdapters.ClientApplication.VM
{
    public record ListClientsResponse
    {

        public List<ClientResponse> Clients { get; set; }
    }
}
