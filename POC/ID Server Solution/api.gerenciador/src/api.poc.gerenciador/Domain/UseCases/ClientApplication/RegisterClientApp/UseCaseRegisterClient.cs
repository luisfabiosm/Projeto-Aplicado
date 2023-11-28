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
                using (var _request = new CreateClientKeycloak(transaction))
                {

                    transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);

                    var _ret = await _identityService.CreateClientAsync(transaction.ClientInfo.Realm, _request);

                    transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(_ret);
                    transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;

                    return handleReturn(_ret);
                }

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
