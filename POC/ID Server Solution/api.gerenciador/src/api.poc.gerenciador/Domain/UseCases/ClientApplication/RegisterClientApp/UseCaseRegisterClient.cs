using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Inbound;
using Newtonsoft.Json;

namespace Domain.UseCases.ClientApplication.RegisterClientApp
{
    public class UseCaseRegisterClient : BaseUseCase, IUseCaseRegisterClientPort
    {
        public UseCaseRegisterClient(IServiceProvider serviceProvider) : base(serviceProvider)
        {


        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionRegisterClient transaction)
        {
            try
            {
                using (var _request = new CreateClientKeycloak(transaction))
                {

                    transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);


                    //criar client
                    var _retcliId = await _identityService.CreateClientAsync(transaction.ClientInfo.Realm, _request);

                    //criar scope , 
                    string _scopeName = transaction.ClientInfo.ClientId + "-scopes";
                    var _requestScope = new CreateClientScopesRequest
                    {
                        Description = $"Testes de criacao via API para: {_scopeName}",
                        Name = _scopeName,
                        Protocol = "openid-connect",
                        Attributes = new Dictionary<string, string>()
                        {
                          { "consent.screen.text", "" },
                          { "display.on.consent.screen", "false" },
                        }
                    };
                    var _retcliscopeId = await _identityService.CreateClientScopes(transaction.ClientInfo.Realm, _requestScope);

                    //mapper
                    var _retMapper = _identityService.CreateProtocolMapperClientScope(transaction.ClientInfo.Realm, _retcliscopeId, transaction.ClientInfo.ClientId, _scopeName + "Mapper", transaction.ClientInfo.ClientName);

                    //config scope into client
                    var _retAdd = _identityService.AddClientScopeAsDefaultToClient(transaction.ClientInfo.Realm, transaction.ClientInfo.ClientId, _retcliscopeId);

                    var _retClientConfig = _identityService.GetClientById(transaction.ClientInfo.Realm, _retcliId);

                    var _oidc = _retClientConfig.Result;

                    var _client = new Client
                    {
                        clientid = transaction.ClientInfo.ClientId,
                        id = _retcliId,
                        createdat = DateTime.UtcNow,
                        isactive = true,
                        publicclient = true,
                        email = transaction.ClientInfo.Email,
                        name = transaction.ClientInfo.ClientName,
                        appidentityconfiguration = _oidc,
                        realm = transaction.ClientInfo.Realm

                    };


                    _client = await _repo.AddNewClient(_client);

                    transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(_client);
                    transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;

                    return handleReturn(new ClientResponse(_client));
                }

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
