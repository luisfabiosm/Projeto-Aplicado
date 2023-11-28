using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Models.Entities;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.UseCases.Users.CreateUser;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {
        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log, BaseTransaction transaction);

        ValueTask<LogTransaction> UpdateLogTransaction(BaseTransaction transaction);

        ValueTask<User> AddNewUser(TransactionCreateUser transaction, UserRepresentation user);

        ValueTask<User> GetUser(string realm, string clientid, string username);

    }
}
