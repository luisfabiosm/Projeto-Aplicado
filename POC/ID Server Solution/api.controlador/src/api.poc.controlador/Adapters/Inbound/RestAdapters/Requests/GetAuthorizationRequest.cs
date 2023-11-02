using System.ComponentModel.DataAnnotations;

namespace Endpoints.VM.Requests
{
    public record GetAuthorizationRequest
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar o user")]
        public string? user { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar a secret")]
        public string? secret { get; set; }

    }
}
