using System.ComponentModel.DataAnnotations;

namespace Adapters.Inbound.RestAdapters.VM
{
    public struct GetAuthorizationResponse
    {
        public string? token { get; set; }
        public DateTime? dataExpiracao { get; set; }
        public DateTime? dataCriacao { get; set; }
    }
}
