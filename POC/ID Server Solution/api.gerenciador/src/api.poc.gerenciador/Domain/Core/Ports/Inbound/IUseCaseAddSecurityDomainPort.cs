using Domain.Core.Base;
using Domain.UseCases.SecurityDomain.AddSecurityDomain;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseAddSecurityDomainPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionAddSecurityDomain transaction);
    }
}
