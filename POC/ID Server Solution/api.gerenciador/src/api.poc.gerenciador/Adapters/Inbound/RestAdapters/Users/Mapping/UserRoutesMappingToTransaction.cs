using Domain.UseCases.Users.GetUser;

namespace Adapters.Inbound.RestAdapters.Users.Mapping
{
    public static class UserRoutesMappingToTransaction
    {
        public static TransactionGetUsers ToTransactionGetUsers(string realm, string username)
        {

            return new TransactionGetUsers
            {
                Realm = realm,
                Username = username,
       
            };

        }



    }
}
