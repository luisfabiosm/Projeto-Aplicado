using Adapters.IdentityProvider.Interfaces;
using Domain.Core.Contracts;
using Domain.Core.Models.Entities;
using Domain.Core.Models.Settings;
using Domain.Core.Models.VO;
using Microsoft.Extensions.Options;
using Refit;

namespace Adapters.IdentityProvider.Provider
{
    public class IdentityProviderService : IIdentityProviderService
    {
        internal IdentitySettings _settingsExternalIdentity;
        private readonly IKeycloakService _identityClient;

        public IdentityProviderService(IServiceProvider serviceProvider)
        {
            _settingsExternalIdentity = serviceProvider.GetRequiredService<IOptions<IdentitySettings>>().Value;
            _identityClient = RestService.For<IKeycloakService>(_settingsExternalIdentity.Token.Endpoint);
        }

        public async Task<TokenInfo> ExecuteGetToken(AuthCredentials credentials)
        {
            return await _identityClient.GetAccessTokenAsync(credentials.GrantType, credentials.ClientId, credentials.Username, credentials.Password, credentials.Secret);
        }

    }
}
