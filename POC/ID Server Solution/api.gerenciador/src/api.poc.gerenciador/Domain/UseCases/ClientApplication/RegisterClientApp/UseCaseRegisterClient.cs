using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.ClientApplication.RegisterClientApp
{
    public class UseCaseRegisterClient : BaseUseCase, IUseCaseRegisterClientPort
    {
        public UseCaseRegisterClient(IServiceProvider serviceProvider) : base(serviceProvider)
        {


        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionRegisterClient transaction)
        {
            try
            {
                using (var _request = new CreateClientRequest(transaction))
                {

                    transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog);

                    var _ret = await _identityService.CreateClientAsync(transaction.ClientInfo.Realm, _request);

                    return handleReturn(_ret);
                }

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
