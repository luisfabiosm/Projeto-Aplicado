using Domain.Core.Base;
using Domain.UseCases.GetUserAuthorization;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseGetUserAuthorization
    {
        Task<BaseReturn> ExecuteTransaction(TransactionGetAuthorization transaction);
    }
}
