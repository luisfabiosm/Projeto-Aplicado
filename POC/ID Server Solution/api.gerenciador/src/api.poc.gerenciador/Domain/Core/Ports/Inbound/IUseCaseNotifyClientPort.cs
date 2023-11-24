using Domain.Core.Base;
using Domain.UseCases.ClientApplication.NotifyClientApp;
using Domain.UseCases.SecurityDomain.AddSecurityDomain;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseNotifyClientPort
    {

        Task<BaseReturn> ExecuteTransaction(TransactionNotifyClientApp transaction);
    }
}
