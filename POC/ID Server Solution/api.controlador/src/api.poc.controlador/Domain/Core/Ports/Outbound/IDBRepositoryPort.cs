using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {
        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log, BaseTransaction transaction = null);

        ValueTask<LogTransaction> UpdateLogTransaction(BaseTransaction transaction);

       // ValueTask<Operator> GetAuthenticationInfo(string user, string secret);

        ValueTask<bool> UpdateAuthenticationInfo(TokenInfo token, string user, string secret);
    }
}
