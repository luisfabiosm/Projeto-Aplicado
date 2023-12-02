using Adapters.Inbound.RestAdapters.VM;
using Domain.UseCases.GetUserAuthorization;

namespace Adapters.Inbound.RestAdapters.Mapping
{
    public static class MappingToTransaction
    {

        public static TransactionGetAuthorization ToTransactionGetAuthorization(GetAuthorizationRequest request)
        {

            return new TransactionGetAuthorization(DateTime.UtcNow)
            {
                TransactionCode = 101,
                UserRequest = request.username,
                PassworRequest = request.password,
                ClientId = request.clientid,
                Realm = request.realm,

            };

        }

    }
}
