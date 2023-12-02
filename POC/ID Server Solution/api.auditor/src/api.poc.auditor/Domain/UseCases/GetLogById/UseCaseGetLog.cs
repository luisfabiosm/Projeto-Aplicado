using Domain.Core.Base;
using Domain.Core.Ports.Inbound;

namespace Domain.UseCases.GetLogById
{
    public class UseCaseGetLog : BaseUseCase, IUseCaseGetLogPort
    {
        public UseCaseGetLog(IServiceProvider serviceProvider): base(serviceProvider)
        {
                
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionGetLog transaction)
        {
            throw new NotImplementedException();
        }
    }
}
