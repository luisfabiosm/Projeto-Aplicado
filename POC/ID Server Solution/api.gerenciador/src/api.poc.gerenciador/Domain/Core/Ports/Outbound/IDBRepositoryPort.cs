using Domain.Core.Models.Dto;
using Domain.Core.Models.Entities;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBRepositoryPort
    {
        ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log);

        ValueTask<LogTransaction> UpdateLogTransaction(LogTransaction log);

    }
}
