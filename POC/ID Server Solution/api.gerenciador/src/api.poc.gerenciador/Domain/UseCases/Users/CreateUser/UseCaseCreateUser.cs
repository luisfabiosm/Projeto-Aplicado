using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.Users.CreateUser
{
    public class UseCaseCreateUser : BaseUseCase, IUseCaseCreateUserPort
    {

        public UseCaseCreateUser(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionCreateUser transaction)
        {
            try
            {
                using (var _request = new CreateUserRequest(transaction))
                {

                    transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog);

                    var _retUser = await _identityService.CreateUserAsync(transaction.UserInfo.Realm, _request);

                    return handleReturn(_retUser);
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
