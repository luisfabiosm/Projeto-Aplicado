using Adapters.Inbound.RestAdapters.Users.Mapping;
using Adapters.Inbound.RestAdapters.Users.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.Users.Routes
{
    public static class ListUsersRoute
    {
        public static void AddListUsersEndpoint(this WebApplication app)
        {
            app.MapGet("gerenciador/v1/users/all", ProcRequest)
             .WithTags("List Users")
             .Produces<ListUsersResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseListUsersPort useCase, string realm, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(UserRoutesMappingToTransaction.ToTransactionListUsers(realm));
                return UserRoutesMappingToResponse.ToTransactionListUsersResponse(response.GetResponse());
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
