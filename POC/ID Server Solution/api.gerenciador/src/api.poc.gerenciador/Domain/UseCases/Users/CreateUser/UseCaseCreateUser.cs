using Adapters.Inbound.RestAdapters.Users.VM;
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
                using (var _request = new CreateUserKeycloak(transaction))
                {

                    transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);

                    var _retUser = await _identityService.CreateUserAsync(transaction.UserInfo.Realm, _request);

                    var _userInfo = await _identityService.GetUsersById(transaction.UserInfo.Realm, _retUser);

                    var _retInfoUser = await _repo.AddNewUser(transaction, _userInfo);

                    transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(_userInfo);
                    transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;

                    return handleReturn(new CreateUserResponse(_retInfoUser));
                }

            }
            catch (Exception ex)
            {
                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(ex);
                transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;
                return handleReturn(ex);
            }
            finally
            {
                await _repo.UpdateLogTransaction(transaction);
            }
        }
    }
}
