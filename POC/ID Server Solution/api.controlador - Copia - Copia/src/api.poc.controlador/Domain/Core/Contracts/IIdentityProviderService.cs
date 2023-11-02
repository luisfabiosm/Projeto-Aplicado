using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;

namespace Domain.Core.Contracts
{
    public interface IIdentityProviderService
    {
        Task<TokenInfo> ExecuteGetToken(AuthCredentials credentilals);
    }
}
