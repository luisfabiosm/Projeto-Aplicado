using Domain.Core.Base;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.ClientApplication.ListClientsApp
{
    public class UseCaseListClientsApp : BaseUseCase, IUseCaseListClientsAppPort
    {
        public UseCaseListClientsApp(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionListClients transaction)
        {
            try
            {
                var _retRealm = await _identityService.GetClients(transaction.Realm);

                return handleReturn(_retRealm);
            }
            catch (Exception ex)
            {
                transaction.TransactionLog.TranResponseInfo = JsonConvert.SerializeObject(ex);
                return handleReturn(ex);
            }
            finally
            {
                await _repo.UpdateLogTransaction(transaction.TransactionLog);
            }
        }
    }
}
