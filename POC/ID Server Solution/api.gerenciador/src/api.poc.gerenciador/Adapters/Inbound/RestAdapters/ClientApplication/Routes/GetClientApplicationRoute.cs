using Adapters.Inbound.RestAdapters.ClientApplication.Mapping;
using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Adapters.Inbound.RestAdapters.SecurityDomain.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.ClientApplication.Routes
{
    public static class GetClientApplicationRoute
    {

        public static void AddGetClientApplicationEndpoint(this WebApplication app)
        {
            app.MapGet("gerenciador/v1/client", ProcRequest)
             .WithTags("Get Client Application")
             .Produces<ClientResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseGetClientPort useCase, string realm, string clientId, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(ClientApplicationMappingToTransaction.ToTransactionGetClient(realm, clientId));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
          


    }
}
