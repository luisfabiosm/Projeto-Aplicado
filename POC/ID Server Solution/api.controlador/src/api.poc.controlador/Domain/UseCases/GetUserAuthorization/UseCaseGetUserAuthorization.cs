using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

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


                //var operatorret = await UseCaseValidation(transaction);
                //if (operatorret is null)
                //    return handleReturn(new Exception("User e Secret não registrados ou inativos."));


                var _operator = new AuthCredentials(transaction);

                var tokenret = await _identityService.ExecuteGetToken(_operator);

                //var updateret = await _repo.UpdateAuthenticationInfo(JsonConvert.DeserializeObject<TokenInfo>(tokenret.ToString()),
                //                                                    transaction.UserRequest,
                //                                                    transaction.SecretRequest);

                //if (!updateret)
                //    return handleReturn(new Exception("Erro na atualização de retorno da geração do token."));

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

        //private async Task<Operator> UseCaseValidation(TransactionGetAuthorization transaction)
        //{
        //    var ret = await _repo.GetAuthenticationInfo(transaction.UserRequest, transaction.PassworRequest);
        //    return ret;
        //}
    }
}
