using Domain.Core.Base;
using Newtonsoft.Json;

namespace Domain.UseCases.ClientApplication.ListClientsApp
{
    public record TransactionListClients : BaseTransaction
    {
        public string Realm { get; set; }



        public TransactionListClients()
        {

        }

        public TransactionListClients(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 702;
            TransactionDate = date;
        }






    }
}
