using Adapters.Inbound.RestAdapters.Notification.VM;
using Domain.UseCases.Notification.NotifyClientApp;
using Domain.UseCases.Notification.NotifyUser;

namespace Adapters.Inbound.RestAdapters.Notification.Mapping
{
    public static class NotificationMappingToTransaction
    {

        public static TransactionNotifyUser ToTransactionNotifyUser(NotifyUserRequest request)
        {

            return new TransactionNotifyUser(DateTime.UtcNow)
            {
                Realm = request.Realm,
                Username = request.Username,
                ClientId = request.ClientId,

            };

        }


        public static TransactionNotifyClientApp ToTransactionNotifyClientApp(NotifyClientRequest request)
        {

            return new TransactionNotifyClientApp(DateTime.UtcNow)
            {
                Realm = request.Realm,
                ClientId = request.ClientId,

            };

        }

     
    }
}
}
