using Domain.Core.Base;
using Domain.UseCases.Users.ListUsers;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseListUsersPort
    {

        Task<BaseReturn> ExecuteTransaction(TransactionListUsers transaction);
    }
}
