using Adapters.Inbound.RestAdapters.ClientApplication.Mapping;
using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Adapters.Inbound.RestAdapters.SecurityDomain.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.ClientApplication.Routes
{
    public static class RegisterClientApplicationRoute
    {

        public static void AddRegisterClientApplicationEndpoint(this WebApplication app)
        {
            app.MapPost("gerenciador/v1/client", ProcRequest)
             .WithTags("Add Client Application")
             .Accepts<RegisterClientRequest>("application/json")
             .Produces<RegisterClientResponse>(StatusCodes.Status200OK)
             .Produces<AddSecurityDomainResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseRegisterClientPort useCase, RegisterClientRequest request, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(ClientApplicationMappingToTransaction.ToTransactionRegisterClient(request));
                return ClientApplicationMappingToResponse.ToTransactionRegisterClientResponse(response.GetResponse());
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }


    }
}
