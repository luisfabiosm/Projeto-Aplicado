using Domain.Core.Base;
using Newtonsoft.Json;

namespace Domain.UseCases.SecurityDomain.AddSecurityDomain
{
    public record TransactionAddSecurityDomain : BaseTransaction
    {
        public string Realm { get; set; }

        public TransactionAddSecurityDomain()
        {

        }

        public TransactionAddSecurityDomain(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 900;
            TransactionDate = date;
        }

      

      


    }
}
