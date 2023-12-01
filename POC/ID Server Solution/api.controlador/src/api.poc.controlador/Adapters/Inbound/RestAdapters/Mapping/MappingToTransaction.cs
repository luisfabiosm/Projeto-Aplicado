using Adapters.Inbound.RestAdapters.VM;
using Domain.UseCases.GetUserAuthorization;

namespace Adapters.Inbound.RestAdapters.Mapping
{
    public static  class MappingToTransaction
    {

        public static TransactionGetAuthorization ToTransactionGetAuthorization(GetAuthorizationRequest request)
        {

            return new TransactionGetAuthorization
                {
                    TransactionCode = 100,
                    UserRequest = request.username,
                    PassworRequest = request.password,
                    ClientId = request.clientid,
                    Realm = request.realm,

                };

        }

    }
}
