
using Adapters.Inbound.RestAdapters.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;
using Domain.UseCases.GetLogById;
using Domain.UseCases.ListLogsByFilter;

namespace Adapters.Inbound.RestAdapters.Routes
{
    public static class ListLogsRoute
    {

        public static void AddListLogsEndpoint(this WebApplication app)
        {
            app.MapGet("auditor/v1/logs/", ProcRequest)
             .WithTags("List Logs")
             .Produces<ListLogsReponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> ProcRequest(IUseCaseListLogsPort useCase, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(new TransactionListLogs());
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
