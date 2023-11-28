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

                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(_retRealm);
                transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;
                return handleReturn(_retRealm);
            }
            catch (Exception ex)
            {
                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(ex);
                transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.PENDING;
                return handleReturn(ex);
            }
            finally
            {
                await _repo.UpdateLogTransaction(transaction);
            }
        }
    }
}
