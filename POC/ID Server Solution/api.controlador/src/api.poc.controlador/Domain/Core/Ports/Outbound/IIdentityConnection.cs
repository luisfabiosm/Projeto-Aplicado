using Adapters.Outbound.IdentityAdapter.KeycloakPorts;

namespace Domain.Core.Ports.Outbound
{
    public interface IIdentityConnection
    {
        IKeycloakAdminAPIPort Connection();

        //string GetAuthToken(string realm = "");


    }
}
