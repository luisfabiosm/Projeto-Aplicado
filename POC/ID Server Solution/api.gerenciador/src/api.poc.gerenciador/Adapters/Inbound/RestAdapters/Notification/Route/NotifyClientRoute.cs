using Adapters.Inbound.RestAdapters.Notification.Mapping;
using Adapters.Inbound.RestAdapters.Notification.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.Notification.Route
{
    public static class NotifyClientRoute
    {

        public static void AddNotifyClientEndpoint(this WebApplication app)
        {
            app.MapPost("gerenciador/v1/notification/client", ProcRequest)
             .WithTags("Notify Client")
             .Accepts<NotifyClientRequest>("application/json")
             .Produces<NotifyClientResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseNotifyClientPort useCase, NotifyClientRequest request, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(NotificationMappingToTransaction.ToTransactionNotifyClientApp(request));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
