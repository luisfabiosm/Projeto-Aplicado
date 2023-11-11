using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {
        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log);

        ValueTask<LogTransaction> UpdateLogTransaction(LogTransaction log);

        ValueTask<Operator> GetAuthenticationInfo(string user, string secret);

        ValueTask<bool> UpdateAuthenticationInfo(TokenInfo token, string user, string secret);
    }
}
