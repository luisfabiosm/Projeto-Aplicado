using Domain.Core.Base;
using Domain.UseCases.GetLogById;


namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseGetLogPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionGetLog transaction);

    }
}
