
using Domain.Core.Base;
using Domain.Core.Models.Entities;

namespace Domain.UseCases.GetAuthorization
{
    public record TransactionGetAuthorization : BaseTransaction
    {

        public string UserRequest { get; set; }
        public string SecretRequest { get; set; }
        public AuthCredentials Credentilas { get; set; }

    }
}
