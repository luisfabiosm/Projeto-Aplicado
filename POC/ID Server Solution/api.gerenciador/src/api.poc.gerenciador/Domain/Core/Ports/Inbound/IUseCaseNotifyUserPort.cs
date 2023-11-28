using Domain.Core.Base;
using Domain.UseCases.Notification.NotifyUser;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseNotifyUserPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionNotifyUser transaction);
    }
}
