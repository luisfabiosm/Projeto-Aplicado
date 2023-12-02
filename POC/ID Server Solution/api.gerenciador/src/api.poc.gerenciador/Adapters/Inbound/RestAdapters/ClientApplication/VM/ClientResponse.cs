

using Domain.Core.Models.Entities;

namespace Adapters.Inbound.RestAdapters.ClientApplication.VM
{
    public record ClientResponse : Client
    {



        public ClientResponse(Client client)
        {

            realm = client.realm;
            id = client.id;
            clientid = client.clientid;
            name = client.name;
            publicclient = client.publicclient;
            createdat = client.createdat;
            isactive = client.isactive;
            email = client.email;
            appidentityconfiguration = client.appidentityconfiguration;

        }

    }
}
