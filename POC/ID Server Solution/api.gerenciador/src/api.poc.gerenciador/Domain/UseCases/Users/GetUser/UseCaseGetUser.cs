using Domain.Core.Base;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.Users.GetUser
{
    public class UseCaseGetUser : BaseUseCase, IUseCaseGetUserPort
    {
        public UseCaseGetUser(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionGetUsers transaction)
        {
            try
            {
                transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);
                var _retRealm = await _identityService.GetUsersByUsername(transaction.Realm, transaction.Username);

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
