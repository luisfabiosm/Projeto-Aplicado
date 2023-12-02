using Domain.Core.Base;
using Domain.UseCases.Users.GetUser;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseGetUserPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionGetUsers transaction);

    }
}
