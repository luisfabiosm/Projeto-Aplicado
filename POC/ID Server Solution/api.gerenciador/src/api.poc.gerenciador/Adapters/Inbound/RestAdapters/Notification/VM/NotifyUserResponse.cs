using Domain.Core.Models.Entities;
using Domain.Core.Models.KeycloakAdminAPI;

namespace Adapters.Inbound.RestAdapters.Notification.VM
{
    public record NotifyUserResponse
    {
        public AccessToken AccessTokenConfig { get; set; }

        public NotifyUserResponse(User user)
        {
            this.AccessTokenConfig = new AccessToken
            {

            };
        }
    }
}
