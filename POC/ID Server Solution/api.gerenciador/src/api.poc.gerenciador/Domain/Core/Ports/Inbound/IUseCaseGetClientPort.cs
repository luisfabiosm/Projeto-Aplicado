using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.UseCases.ClientApplication.GetClientApp;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseGetClientPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionGetClient transaction);
    }
}
