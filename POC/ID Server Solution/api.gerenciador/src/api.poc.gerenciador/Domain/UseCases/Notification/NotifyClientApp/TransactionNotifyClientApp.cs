using Domain.Core.Base;

namespace Domain.UseCases.Notification.NotifyClientApp
{
    public record TransactionNotifyClientApp : BaseTransaction
    {
        public string Realm { get; set; }
        public string ClientId { get; set; }


        public TransactionNotifyClientApp()
        {

        }

        public TransactionNotifyClientApp(DateTime date, int code = 799) : base(date, code)
        {
            TransactionCode = 799;
            TransactionDate = date;
        }


    }
}
