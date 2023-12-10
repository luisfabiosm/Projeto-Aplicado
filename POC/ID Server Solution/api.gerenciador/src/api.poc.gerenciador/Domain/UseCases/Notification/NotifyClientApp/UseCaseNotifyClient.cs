using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Inbound;
using Domain.Core.Ports.Outbound;
//using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Domain.UseCases.Notification.NotifyClientApp
{
    public class UseCaseNotifyClient : BaseUseCase, IUseCaseNotifyClientPort
    {

        //mock de serviços d notificação
        private readonly INotifyServicePort _notifyService;

        public UseCaseNotifyClient(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _notifyService = serviceProvider.GetRequiredService<INotifyServicePort>();
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionNotifyClientApp transaction)
        {
 
            try
            {
                transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);

                var _client = await _repo.GetClient(transaction.Realm, transaction.ClientId);

                var _retClients = await _identityService.GetClientById(transaction.Realm, _client.id);
                await _notifyService.SendEmail(_client.email, "Client configuration OIDC", _retClients);

                transaction.TransactionLog.tranresponseinfo = _retClients;
                transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;
                return handleReturn(JsonSerializer.Deserialize<object>(_retClients));
            }
            catch (Exception ex)
            {
                transaction.TransactionLog.tranresponseinfo = JsonSerializer.Serialize(ex);  //JsonConvert.SerializeObject(ex);
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
