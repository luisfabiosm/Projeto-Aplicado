using Adapters.Inbound.RestAdapters.ClientApplication.Mapping;
using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.ClientApplication.Routes
{
    public static class ListClientsApplicationRoute
    {

        public static void AddListClientsApplicationEndpoint(this WebApplication app)
        {
            app.MapGet("gerenciador/v1/client/all", ProcRequest)
             .WithTags("List Clients Application")
             .Produces<ListClientsResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseListClientsAppPort useCase, string realm, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(ClientApplicationMappingToTransaction.ToTransactionListClients(realm));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
