using Adapters.Inbound.RestAdapters.VM;
using Domain.Core.Base;
using Domain.Core.Contracts;
using Domain.Core.Enums;
using Domain.UseCases.GetAuthorization;

namespace Adapters.Inbound.RestAdapters.Routes
{
    public static class GetAuthorizationRoute
    {

        public static void AddGetAuthorizationEndpoint(this WebApplication app)
        {
            app.MapPost("controlador/v1/authorizacao", ProcRequest)
             .WithTags("Get Authorization")
             .Accepts<GetAuthorizationRequest>("application/json")
             .Produces<GetAuthorizationResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> ProcRequest(IUseCaseGetAuthorization useCase, HttpContext context, GetAuthorizationRequest request)
        {
            try
            {
                var _transaction = new TransactionGetAuthorization
                {
                    TransactionCode = "1",
                    UserRequest = request.user,
                    SecretRequest = request.secret,
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
