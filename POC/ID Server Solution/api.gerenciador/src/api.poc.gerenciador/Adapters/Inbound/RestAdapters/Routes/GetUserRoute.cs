using Adapters.Inbound.RestAdapters.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;
using Domain.UseCases.Users.GetUser;

namespace Adapters.Inbound.RestAdapters.Routes
{
    public static class GetUserRoute
    {

        public static void AddGetAuthorizationEndpoint(this WebApplication app)
        {
            app.Get("gerenciador/v1/user", ProcRequest)
             .WithTags("Get User")
             .Produces<GetUserResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);


        }

        private static async Task<IResult> ProcRequest(IUseCaseGetUserPort useCase, string userid, HttpContext context)
        {
            try
            {
                var _transaction = new TransactionGetUser
                {
                    TransactionCode = 100,
                    User = userid,
                };

                var response = await useCase.ExecuteTransaction(_transaction);
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }
    }
}
