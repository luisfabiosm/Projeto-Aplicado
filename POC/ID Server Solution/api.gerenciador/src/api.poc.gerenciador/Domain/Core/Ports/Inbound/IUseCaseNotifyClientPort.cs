using Domain.Core.Base;
using Domain.UseCases.Notification.NotifyClientApp;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseNotifyClientPort
    {

        Task<BaseReturn> ExecuteTransaction(TransactionNotifyClientApp transaction);
    }
}
