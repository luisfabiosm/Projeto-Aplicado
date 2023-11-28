using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Models.Entities;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.UseCases.Users.CreateUser;
using Keycloak.Net.Models.Clients;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {
        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log, BaseTransaction transaction);

        ValueTask<LogTransaction> UpdateLogTransaction(BaseTransaction transaction);

        ValueTask<User> AddNewUser(TransactionCreateUser transaction, UserRepresentation user);

        ValueTask<User> GetUser(string realm, string clientid, string username);

        ValueTask<Models.Entities.Client> AddNewClient(Models.Entities.Client client);

        ValueTask<Models.Entities.Client> GetClient(string realm, string clientid);
    }
}
