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
