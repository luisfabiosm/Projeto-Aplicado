using Domain.Core.Base;
using Domain.Core.Models.Entities;


namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {
        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log, BaseTransaction transaction = null);

        ValueTask<LogTransaction> UpdateLogTransaction(BaseTransaction transaction);

        ValueTask<Client> GetClient(string realm, string clientid);

        ValueTask<User> GetUser(string realm, string clientid, string username);

        //ValueTask<bool> UpdateAuthenticationInfo(TokenInfo token, string user, string secret);
    }
}
