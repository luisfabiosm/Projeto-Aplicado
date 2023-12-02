using Domain.Core.Base;
using Domain.Core.Models.Entities;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {
        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log, BaseTransaction transaction);

        ValueTask<LogTransaction> UpdateLogTransaction(BaseTransaction transaction);

      
    }
}
