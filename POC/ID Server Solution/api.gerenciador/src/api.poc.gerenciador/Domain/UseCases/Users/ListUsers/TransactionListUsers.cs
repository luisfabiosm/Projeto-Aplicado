using Domain.Core.Base;

namespace Domain.UseCases.Users.ListUsers
{
    public record TransactionListUsers : BaseTransaction
    {

        public string Realm { get; set; }



        public TransactionListUsers()
        {

        }

        public TransactionListUsers(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 710;
            TransactionDate = date;
        }
    }
}
