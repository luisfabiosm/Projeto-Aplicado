using Domain.Core.Models.Dto;
using Domain.Core.Models.Entities;
using Domain.UseCases.Users.AddUser;
using Domain.UseCases.Users.GetUser;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {

        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log);

        ValueTask<LogTransaction> UpdateLogTransaction(LogTransaction log);

        ValueTask<UserNotify> AddUser(TransactionAddUser transaction);

        ValueTask<UserNotify> GetUser(TransactionGetUser transaction);

    }
}
