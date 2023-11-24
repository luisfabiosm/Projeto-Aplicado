using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;

namespace Domain.UseCases.ClientApplication.NotifyClientApp
{
    public record TransactionNotifyClientApp : BaseTransaction
    {
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string Email { get; set; }
        public OIDCInstalationToken OIDCConfig { get; set; }

        public TransactionNotifyClientApp()
        {
            
        }

        public TransactionNotifyClientApp(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 799;
            TransactionDate = date;
        }


    }
}
