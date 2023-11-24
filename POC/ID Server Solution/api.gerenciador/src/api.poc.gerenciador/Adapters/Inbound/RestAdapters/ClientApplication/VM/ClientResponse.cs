using Domain.Core.Models.KeycloakAdminAPI;

namespace Adapters.Inbound.RestAdapters.ClientApplication.VM
{
    public record ClientResponse
    {

        public string Id { get; init; }
        public string ClientId { get; init; }
        public string Name { get; init; }
        public string ClientAuthenticatorType { get; init; }
        public int NodeReRegistrationTimeout { get; init; }
        public List<string> DefaultClientScopes { get; init; }
        public List<string> OptionalClientScopes { get; init; }
        public Access Access { get; init; }
        public List<ProtocolMapper> ProtocolMappers { get; init; }

    }
}
