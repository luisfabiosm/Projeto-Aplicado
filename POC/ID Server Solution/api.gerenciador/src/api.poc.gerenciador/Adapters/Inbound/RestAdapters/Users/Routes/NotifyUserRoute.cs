using Adapters.Inbound.RestAdapters.Users.Mapping;
using Adapters.Inbound.RestAdapters.Users.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.Users.Routes
{
    public static class NotifyUserRoute
    {

        public static void AddNotifyUsersEndpoint(this WebApplication app)
        {
            app.MapPost("gerenciador/v1/notification/user", ProcRequest)
             .WithTags("Notify Users")
             .Accepts<NotifyUserRequest>("application/json")
             .Produces<NotifyUserResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseNotifyUserPort useCase,NotifyUserRequest request, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(UserRoutesMappingToTransaction.ToTransactionNotifyUser(request));
                return UserRoutesMappingToResponse.ToTransactionNotifyUserResponse(response.GetResponse());
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
