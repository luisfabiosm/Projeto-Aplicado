using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;

namespace Domain.Core.Ports.Outbound
{
    public interface IIdentityServerServicePort
    {
        Task<TokenInfo> ExecuteGetToken(AuthCredentials credentilals);
    }
}
