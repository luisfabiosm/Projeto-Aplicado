namespace Adapters.Inbound.RestAdapters.SecurityDomain.VM
{
    public record AddSecurityDomainRequest
    {
        public string Realm { get; set; }
    }
}
