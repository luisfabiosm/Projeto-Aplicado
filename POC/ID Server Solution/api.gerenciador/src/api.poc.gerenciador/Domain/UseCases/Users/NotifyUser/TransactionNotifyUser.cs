using Domain.Core.Base;

namespace Domain.UseCases.Users.NotifyUser
{
    public record TransactionNotifyUser : BaseTransaction
    {
        public string Realm { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }


        public TransactionNotifyUser()
        {

        }

        public TransactionNotifyUser(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 798;
            TransactionDate = date;
        }
    }
}
