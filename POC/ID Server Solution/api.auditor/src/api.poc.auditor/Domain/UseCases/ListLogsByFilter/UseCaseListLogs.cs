using Domain.Core.Base;
using Domain.Core.Ports.Inbound;

namespace Domain.UseCases.ListLogsByFilter
{
    public class UseCaseListLogs : BaseUseCase, IUseCaseListLogsPort
    {
        public UseCaseListLogs(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionListLogs transaction)
        {
            throw new NotImplementedException();
        }
    }
}
