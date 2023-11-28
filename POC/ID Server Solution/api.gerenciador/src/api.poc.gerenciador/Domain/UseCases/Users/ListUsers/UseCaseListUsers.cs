using Domain.Core.Base;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.Users.ListUsers
{
    public class UseCaseListUsers : BaseUseCase, IUseCaseListUsersPort
    {
        public UseCaseListUsers(IServiceProvider serviceProvider) : base(serviceProvider)
        {


        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionListUsers transaction)
        {
            try
            {
                var _retRealm = await _identityService.GetUsers(transaction.Realm);

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
