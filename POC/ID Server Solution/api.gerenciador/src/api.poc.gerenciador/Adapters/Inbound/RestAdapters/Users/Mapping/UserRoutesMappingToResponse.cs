using Adapters.Inbound.RestAdapters.ClientApplication.VM;
using Adapters.Inbound.RestAdapters.Notification.VM;
using Adapters.Inbound.RestAdapters.Users.VM;
using Domain.Core.Models.Entities;
using Domain.Core.Models.KeycloakAdminAPI;


namespace Adapters.Inbound.RestAdapters.Users.Mapping
{
    public static class UserRoutesMappingToResponse
    {
        private static IResult ReturnMapping(object ret)
        {
            return Results.Ok(ret);
        }


        public static IResult ToTransactionNotifyUserResponse(dynamic useCaseResponse)
        {
            var _useCaseResponse = (NotifyUserResponse)useCaseResponse;

            return ReturnMapping(
            new NotifyUserResponse
            {
                NotificationId = _useCaseResponse.NotificationId,
                NotificationDate =  DateTime.UtcNow,

            }
            );

        }

      

        public static IResult ToTransactionGetUserResponse(dynamic useCaseResponse)
        {
            var _useCaseResponse = (UserConfiguration)useCaseResponse;

            return ReturnMapping(
            new GetUserResponse
            {
                Username = _useCaseResponse.Username,
                FirstName = _useCaseResponse.FirstName,
                LastName = _useCaseResponse.LastName,
                Email = _useCaseResponse.Email,
                Id = _useCaseResponse.Id,

            }
            );

        }


        public static IResult ToTransactionListUsersResponse(dynamic useCaseResponse)
        {

            return ReturnMapping(useCaseResponse);

        }

    }
}
