using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Adapters.Inbound.RestAdapters.SecurityDomain.VM;
using Domain.UseCases.ClientApplication.RegisterClientApp;
using Domain.UseCases.SecurityDomain.AddSecurityDomain;

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

    }
}
