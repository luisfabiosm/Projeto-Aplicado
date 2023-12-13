using Adapters.Outbound.IdentityServerAdapter.KeycloakPorts;

namespace Domain.Core.Ports.Outbound
{
    public interface IIdentityConnection
    {
        IKeycloakAdminAPIPort Connection();

        //string GetAuthToken(string realm = "");


    }
}
