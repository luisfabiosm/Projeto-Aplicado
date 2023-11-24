using Adapters.Inbound.RestAdapters.SecurityDomain.Mapping;
using Adapters.Inbound.RestAdapters.SecurityDomain.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.SecurityDomain.Routes
{
    public static class AddSecurityDomainRoute
    {

        public static void AddSecurityDomainEndpoint(this WebApplication app)
        {
            app.MapPost("gerenciador/v1/domain", ProcRequest)
             .WithTags("Add Security Domain")
             .Accepts<AddSecurityDomainRequest>("application/json")
             .Produces<AddSecurityDomainResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseAddSecurityDomainPort useCase, AddSecurityDomainRequest request, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(SecurityDomainMappingToTransaction.ToTransactionAddSecurityDomain(request));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
