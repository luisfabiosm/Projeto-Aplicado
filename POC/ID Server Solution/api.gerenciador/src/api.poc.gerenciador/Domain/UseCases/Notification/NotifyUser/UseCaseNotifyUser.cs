using Adapters.Inbound.RestAdapters.Notification.VM;
using Domain.Core.Base;
using Domain.Core.Ports.Inbound;
using Domain.Core.Ports.Outbound;
using Newtonsoft.Json;

namespace Domain.UseCases.Notification.NotifyUser
{
    public class UseCaseNotifyUser : BaseUseCase, IUseCaseNotifyUserPort
    {
        //mock de serviços d notificação
        private readonly INotifyServicePort _notifyService;

        public UseCaseNotifyUser(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _notifyService = serviceProvider.GetRequiredService<INotifyServicePort>();
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionNotifyUser transaction)
        {
            try
            {
                transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);

                var _retUser = await _identityService.GetUsersByUsername(transaction.Realm, transaction.Username);

                var _userInfo = await _repo.GetUser(transaction.Realm, transaction.ClientId, transaction.Username);

                var _notificationId = await _notifyService.SendEmail(_userInfo.email, "User information para Access Token", _userInfo.identityuserinfo);

                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(_userInfo);
                transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;

                return handleReturn( new NotifyUserResponse(_userInfo));
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
