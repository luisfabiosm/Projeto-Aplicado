using Domain.Core.Base;

namespace Domain.UseCases.Users.GetUser
{
    public record TransactionGetUsers : BaseTransaction
    {
        public string Realm { get; set; }

        public string Username { get; internal set; }

        public TransactionGetUsers()
        {

        }

        public TransactionGetUsers(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 711;
            TransactionDate = date;
        }
    }
}
