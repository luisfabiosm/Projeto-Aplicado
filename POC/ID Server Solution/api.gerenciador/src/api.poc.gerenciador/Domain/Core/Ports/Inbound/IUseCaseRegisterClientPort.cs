using Domain.Core.Base;
using Domain.UseCases.ClientApplication.RegisterClientApp;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseRegisterClientPort
    {

        Task<BaseReturn> ExecuteTransaction(TransactionRegisterClient transaction);
    }
}
