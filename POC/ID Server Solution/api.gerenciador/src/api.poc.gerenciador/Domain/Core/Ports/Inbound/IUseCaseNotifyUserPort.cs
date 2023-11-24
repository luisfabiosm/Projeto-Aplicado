using Domain.Core.Base;
using Domain.UseCases.ClientApplication.NotifyClientApp;
using Domain.UseCases.Users.NotifyUser;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseNotifyUserPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionNotifyUser transaction);
    }
}
