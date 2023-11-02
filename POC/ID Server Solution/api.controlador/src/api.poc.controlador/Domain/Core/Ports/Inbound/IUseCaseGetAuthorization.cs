using Domain.Core.Base;
using Domain.UseCases.GetAuthorization;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseGetAuthorization
    {
        Task<BaseReturn> ExecuteTransaction(TransactionGetAuthorization transaction);
    }
}
