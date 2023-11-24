using Domain.Core.Base;
using Domain.UseCases.ClientApplication.GetClientApp;
using Domain.UseCases.Users.CreateUser;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseCreateUserPort
    {

        Task<BaseReturn> ExecuteTransaction(TransactionCreateUser transaction);
    }
}
