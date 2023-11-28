using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.ClientApplication.GetClientApp
{
    public class UseCaseGetClient : BaseUseCase, IUseCaseGetClientPort
    {
        public UseCaseGetClient(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionGetClient transaction)
        {
            try
            {
                transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);
                var _retRealm = await _identityService.GetClientByClienId(transaction.Realm, transaction.ClientId);

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
