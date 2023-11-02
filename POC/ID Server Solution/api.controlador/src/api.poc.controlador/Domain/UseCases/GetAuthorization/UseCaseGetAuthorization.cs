using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;
using Domain.Core.Ports.Inbound;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Domain.UseCases.GetAuthorization
{
    public class UseCaseGetAuthorization : BaseUseCase, IUseCaseGetAuthorization
    {

        public UseCaseGetAuthorization(IServiceProvider serviceProvider): base(serviceProvider)
        {
            
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionGetAuthorization transaction)
        {
            try
            {
              
                    var operatorret = await UseCaseValidation(transaction);
                    if (operatorret is null)
                        return handleReturn(new Exception("User e Secret não registrados ou inativos."));

                    var tokenret = await _identityService.ExecuteGetToken(transaction.Credentilas);

                    var updateret = await _repo.UpdateAuthenticationInfo(JsonConvert.DeserializeObject<TokenInfo>(tokenret.ToString()), transaction.OIDConfiguration.Username, transaction.OIDConfiguration.Secret);
                    if (!updateret)
                        return handleReturn(new Exception("Erro na atualização de retorno da geração do token."));

                    return handleReturn(tokenret);
                
            }
            catch (Exception ex)
            { return handleReturn(ex); }
        }

        private async Task<Operator> UseCaseValidation(TransactionGetAuthorization transaction)
        {
            var ret = await _repo.GetAuthenticationInfo(transaction.UserRequest, transaction.SecretRequest);
            return ret;
        }
    }
}
