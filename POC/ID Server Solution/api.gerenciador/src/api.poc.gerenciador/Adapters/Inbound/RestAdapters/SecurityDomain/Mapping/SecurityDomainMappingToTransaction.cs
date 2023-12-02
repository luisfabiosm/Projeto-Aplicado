using Adapters.Inbound.RestAdapters.SecurityDomain.VM;
using Domain.UseCases.SecurityDomain.AddSecurityDomain;

namespace Adapters.Inbound.RestAdapters.SecurityDomain.Mapping
{
    public static class SecurityDomainMappingToTransaction
    {
        public static TransactionAddSecurityDomain ToTransactionAddSecurityDomain(AddSecurityDomainRequest request)
        {

            return new TransactionAddSecurityDomain(DateTime.Now)
            {
                Realm = request.Realm,
            };

        }
    }
}
