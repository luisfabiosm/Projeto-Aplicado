using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;
using System.Net;

namespace Domain.UseCases.GetUserAuthorization
{
    public class UseCaseGetUserAuthorization : BaseUseCase, IUseCaseGetUserAuthorization
    {

        public UseCaseGetUserAuthorization(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionGetAuthorization transaction)
        {
            try
            {

                transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);


                var retClient = await UseCaseValidation(transaction);
                if (retClient is null)
                    return handleReturn(new Exception("User não registrado para consumir esse ClientId."));


                var _operator = new AuthCredentials(transaction, retClient);

                var tokenret = await _identityService.GetAuthToken(_operator);

                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(tokenret);

                return handleReturn(tokenret);


            }
            catch (Exception ex)
            {
                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(ex);
                return handleReturn(ex);
            }
            finally
            {
                await _repo.UpdateLogTransaction(transaction);
            }
        }

        private async Task<Client> UseCaseValidation(TransactionGetAuthorization transaction)
        {
            var retUser = await _repo.GetUser(transaction.Realm, transaction.ClientId, transaction.UserRequest);
            if (retUser is null)
                handleReturn(new Exception("User não registrado."));

            var ret = await _repo.GetClient(transaction.Realm, retUser.clientid);
            return ret;
        }
    }
}
