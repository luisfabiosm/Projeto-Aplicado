using Adapters.Inbound.RestAdapters.Users.Mapping;
using Adapters.Inbound.RestAdapters.Users.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.Users.Routes
{
    public static class GetUserRoute
    {

        public static void AddGetUserEndpoint(this WebApplication app)
        {
            app.MapGet("gerenciador/v1/user", ProcRequest)
             .WithTags("Get User")
             .Produces<GetUserResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseGetUserPort useCase, string realm, string username, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(UserRoutesMappingToTransaction.ToTransactionGetUsers(realm, username));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
