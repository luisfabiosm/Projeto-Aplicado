using Domain.Core.Models.Entities;
using Domain.Core.Models.Keycloak;

namespace Domain.Core.Ports.Outbound
{
    public interface IIdentityServerServicePort
    {
        Task<AccessToken> GetAuthToken(AuthCredentials credentilals);


    }
}
