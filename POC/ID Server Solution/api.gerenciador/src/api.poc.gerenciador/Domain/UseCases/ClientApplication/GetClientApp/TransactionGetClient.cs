using Domain.Core.Base;
using Newtonsoft.Json;

namespace Domain.UseCases.ClientApplication.GetClientApp
{
    public record TransactionGetClient : BaseTransaction
    {
        public string Realm { get; set; }

        public string ClientId { get; set; }

        public TransactionGetClient()
        {

        }

        public TransactionGetClient(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 701;
            TransactionDate = date;
        }






    }
}
