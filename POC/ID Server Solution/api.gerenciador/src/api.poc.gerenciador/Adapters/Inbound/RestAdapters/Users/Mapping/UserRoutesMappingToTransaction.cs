
using Adapters.Inbound.RestAdapters.Notification.VM;
using Adapters.Inbound.RestAdapters.Users.VM;
using Domain.UseCases.Notification.NotifyUser;
using Domain.UseCases.Users.CreateUser;
using Domain.UseCases.Users.GetUser;
using Domain.UseCases.Users.ListUsers;

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

        public static TransactionListUsers ToTransactionListUsers(string realm)
        {

            return new TransactionListUsers
            {
                Realm = realm,
  
            };

        }

       

        public static TransactionCreateUser ToTransactionCreateUser(CreateUserRequest request)
        {

            return new TransactionCreateUser(DateTime.Now)
            {
                UserInfo = new RegistrationUser
                {
                    Realm = request.Realm,
                    ClientId = request.ClientId,
                    Password = request.Password,
                    Username = request.Username,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Credentials = new Domain.Core.Models.KeycloakAdminAPI.UserCredentials[]
                    {
                        new Domain.Core.Models.KeycloakAdminAPI.UserCredentials
                        {
                            Type = "password",
                            Value = request.Password,
                            Temporary = false
                        },
                     },
                }

            };

        }


    }
}
