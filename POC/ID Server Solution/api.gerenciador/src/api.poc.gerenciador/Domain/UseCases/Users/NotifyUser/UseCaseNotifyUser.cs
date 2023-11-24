using Domain.Core.Base;
using Domain.Core.Ports.Inbound;
using Domain.Core.Ports.Outbound;
using Newtonsoft.Json;

namespace Domain.UseCases.Users.NotifyUser
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
                transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog);

                var _retUser = await _identityService.GetUsersByUsername(transaction.Realm, transaction.Username);

                await _notifyService.SendEmail(transaction.Email, "UserInfo", JsonConvert.SerializeObject(_retUser));

                return handleReturn(_retUser);
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
