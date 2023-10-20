using System.ComponentModel.DataAnnotations;

namespace Endpoints.VM.Responses
{
    public struct GetAuthorizationResponse
    {
        public string? token { get; set; }
        public DateTime? dataExpiracao { get; set; }
        public DateTime? dataCriacao { get; set; }
    }
}
