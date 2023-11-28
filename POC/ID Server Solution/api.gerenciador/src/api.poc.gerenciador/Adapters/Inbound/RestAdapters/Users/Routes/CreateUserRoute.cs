using Adapters.Inbound.RestAdapters.SecurityDomain.VM;
using Adapters.Inbound.RestAdapters.Users.Mapping;
using Adapters.Inbound.RestAdapters.Users.VM;
using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Ports.Inbound;

namespace Adapters.Inbound.RestAdapters.Users.Routes
{
    public static class CreateUserRoute
    {

        public static void AddCreateUserEndpoint(this WebApplication app)
        {

            app.MapPost("gerenciador/v1/user", ProcRequest)
             .WithTags("Create User")
             .Accepts<CreateUserRequest>("application/json")
             .Produces<CreateUserResponse>(StatusCodes.Status200OK)
             .Produces<AddSecurityDomainResponse>(StatusCodes.Status200OK)
             .Produces<BaseError>(StatusCodes.Status400BadRequest)
             .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        }

        private static async Task<IResult> ProcRequest(IUseCaseCreateUserPort useCase, CreateUserRequest request, HttpContext context)
        {
            try
            {
                var response = await useCase.ExecuteTransaction(UserRoutesMappingToTransaction.ToTransactionCreateUser(request));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn(ex, EnumReturnType.SYSTEM).GetResponse();
            }
        }

    }
}
