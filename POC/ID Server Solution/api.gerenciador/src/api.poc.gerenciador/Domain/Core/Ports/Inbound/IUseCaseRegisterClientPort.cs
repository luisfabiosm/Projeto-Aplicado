using Domain.Core.Base;
using Domain.UseCases.ClientApplication.RegisterClientApp;
using Domain.UseCases.SecurityDomain.AddSecurityDomain;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseRegisterClientPort
    {

        Task<BaseReturn> ExecuteTransaction(TransactionRegisterClient transaction);
    }
}
