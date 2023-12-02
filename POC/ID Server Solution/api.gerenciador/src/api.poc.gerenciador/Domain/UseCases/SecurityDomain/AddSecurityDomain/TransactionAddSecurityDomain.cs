using Domain.Core.Base;

namespace Domain.UseCases.SecurityDomain.AddSecurityDomain
{
    public record TransactionAddSecurityDomain : BaseTransaction
    {
        public string Realm { get; set; }

        public TransactionAddSecurityDomain()
        {

        }

        public TransactionAddSecurityDomain(DateTime date, int code = 900) : base(date, code)
        {

            TransactionCode = code;
            TransactionDate = date;
        }






    }
}
