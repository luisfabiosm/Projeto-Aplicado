using Domain.Core.Base;

namespace Domain.UseCases.Notification.NotifyUser
{
    public record TransactionNotifyUser : BaseTransaction
    {
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string Username { get; set; }


        public TransactionNotifyUser()
        {

        }

        public TransactionNotifyUser(DateTime date, int code = 798) : base(date, code)
        {
            TransactionCode = 798;
            TransactionDate = date;
        }
    }
}
