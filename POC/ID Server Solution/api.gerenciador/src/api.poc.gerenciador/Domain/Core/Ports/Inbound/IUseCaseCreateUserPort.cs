using Domain.Core.Base;
using Domain.UseCases.Users.CreateUser;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseCreateUserPort
    {

        Task<BaseReturn> ExecuteTransaction(TransactionCreateUser transaction);
    }
}
