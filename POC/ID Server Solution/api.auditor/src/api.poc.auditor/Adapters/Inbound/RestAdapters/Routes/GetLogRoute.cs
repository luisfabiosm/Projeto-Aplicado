
using Adapters.Inbound.RestAdapters.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;
using Domain.UseCases.GetLogById;

namespace Adapters.Inbound.RestAdapters.Routes
{
    public static class GetLogRoute
    {

        public static void AddGetLogEndpoint(this WebApplication app)
        {
            app.MapGet("auditor/v1/log", ProcRequest)
             .WithTags("Get Log")
             .Produces<GetLogResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> ProcRequest(IUseCaseGetLogPort useCase, HttpContext context, string logid)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(new TransactionGetLog());
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
