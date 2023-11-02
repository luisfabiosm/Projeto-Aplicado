using Domain.Core.Base;
using Domain.UseCases.GetAuthorization;

namespace Domain.Core.Contracts
{
    public interface IUseCaseGetAuthorization
    {
        Task<BaseReturn> ExecuteTransaction(TransactionGetAuthorization transaction);

    }
}
