using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Domain.UseCases.ClientApplication.GetClientApp;
using Domain.UseCases.ClientApplication.ListClientsApp;
using Domain.UseCases.ClientApplication.RegisterClientApp;

namespace Adapters.Inbound.RestAdapters.ClientApplication.Mapping
{
    public static class ClientApplicationMappingToTransaction
    {


        public static TransactionRegisterClient ToTransactionRegisterClient(RegisterClientRequest request)
        {

            return new TransactionRegisterClient
            {
                ClientInfo = new RegistrationClient
                {
                    ClientId = request.ClientId,
                    ClientName = request.ClientName,
                    Realm = request.Realm,
                    Description = request.Description,
                }
            };

        }

        public static TransactionGetClient ToTransactionGetClient(string realm, string clientId)
        {

            return new TransactionGetClient
            {
                Realm = realm,
                ClientId = clientId,
                
            };

        }


        public static TransactionListClients ToTransactionListClients(string realm)
        {
            return new TransactionListClients
            {
                Realm = realm,

            };
        }
    }
}
