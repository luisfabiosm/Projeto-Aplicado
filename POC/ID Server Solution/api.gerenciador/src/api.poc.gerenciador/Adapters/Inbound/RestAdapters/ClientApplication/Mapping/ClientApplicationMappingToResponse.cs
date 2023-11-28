using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Domain.Core.Models.KeycloakAdminAPI;


namespace Adapters.Inbound.RestAdapters.ClientApplication.Mapping
{
    public static class ClientApplicationMappingToResponse
    {
        private static IResult ReturnMapping(object ret)
        {
            return Results.Ok(ret);
        }

        //public static IResult ToTransactionRegisterClientResponse(object useCaseResponse)
        //{

        //    return ReturnMapping(
        //    new RegisterClientResponse
        //    {
        //        Id = (string)useCaseResponse,
        //    }
        //    );

        //}

        //public static IResult ToTransactionGetClientResponse(object useCaseResponse)
        //{
        //    var _useCaseResponse = (ClientConfiguration)useCaseResponse;

        //    return ReturnMapping(
        //    new GetClientResponse
        //    {
        //        Id  = _useCaseResponse.Id,
        //        ClientId = _useCaseResponse.ClientId,
        //        Name = _useCaseResponse.Name,
        //        ClientAuthenticatorType = _useCaseResponse.ClientAuthenticatorType,
        //        NodeReRegistrationTimeout = _useCaseResponse.NodeReRegistrationTimeout,
        //        DefaultClientScopes = _useCaseResponse.DefaultClientScopes,
        //        OptionalClientScopes = _useCaseResponse.OptionalClientScopes,
        //        Access = _useCaseResponse.Access,
        //        ProtocolMappers = _useCaseResponse.ProtocolMappers

        //    }
        //    );

    }


    //public static IResult ToTransactionListClientsResponse(object useCaseResponse)
    //{

    //    return ReturnMapping(useCaseResponse);

    //}

}

