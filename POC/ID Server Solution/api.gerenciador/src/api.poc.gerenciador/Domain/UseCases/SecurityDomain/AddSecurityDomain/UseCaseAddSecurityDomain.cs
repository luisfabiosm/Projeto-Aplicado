using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.SecurityDomain.AddSecurityDomain
{
  
    public class UseCaseAddSecurityDomain : BaseUseCase , IUseCaseAddSecurityDomainPort
    {

        public UseCaseAddSecurityDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            
            
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionAddSecurityDomain transaction)
        {

            try
            {
                using (var _request = new CreateRealmRequest(transaction.Realm))
                {

                    transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog);

                    var _retRealm = await _identityService.CreateRealmAsync(_request);

                    return handleReturn(_retRealm);
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
