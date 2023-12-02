using Domain.Core.Base;
using Domain.UseCases.ListLogsByFilter;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseListLogsPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionListLogs transaction);
    }
}
