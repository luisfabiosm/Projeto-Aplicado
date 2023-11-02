using Domain.Core.Models.Entities;
using Domain.Core.Models.Settings;
using Domain.Core.Models.VO;
using Domain.Core.Ports.Outbound;
using Microsoft.Extensions.Options;
using Refit;

namespace Adapters.Outbound.IdentityServerAdapter
{
    public class IdentityServerService : IIdentityServerServicePort
    {
        internal IdentityServerSettings _settingsExternalIdentity;
        private readonly IKeycloakService _identityClient;

        public IdentityServerService(IServiceProvider serviceProvider)
        {
            _settingsExternalIdentity = serviceProvider.GetRequiredService<IOptions<IdentityServerSettings>>().Value;
            _identityClient = RestService.For<IKeycloakService>(_settingsExternalIdentity.Token.Endpoint);
        }

        public async Task<TokenInfo> ExecuteGetToken(AuthCredentials credentials)
        {
            return await _identityClient.GetAccessTokenAsync(credentials.GrantType, credentials.ClientId, credentials.Username, credentials.Password, credentials.Secret);
        }

    }
}
