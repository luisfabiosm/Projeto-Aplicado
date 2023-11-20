using Adapters.Outbound.IdentityAdapter.KeycloakPorts;
using Npgsql;

namespace Domain.Core.Ports.Outbound
{
    public interface IIdentityConnection
    {
        IKeycloakAdminAPIPort Connection();

        string GetAuthToken();


    }
}
