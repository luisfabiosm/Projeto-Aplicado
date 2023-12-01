using System.ComponentModel.DataAnnotations;

namespace Adapters.Inbound.RestAdapters.VM
{
    public record GetAuthorizationRequest
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar o Realm")]
        public string? realm { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar o Username")]
        public string? username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar a Password")]
        public string? password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar o ClientId")]
        public string? clientid { get; set; }


    }
}
