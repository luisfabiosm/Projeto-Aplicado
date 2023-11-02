

using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;

namespace Domain.Core.Contracts
{
    public interface IDBRepository
    {

        ValueTask<Operator> GetAuthenticationInfo(string user, string secret);

        ValueTask<bool> UpdateAuthenticationInfo(TokenInfo token, string user, string secret);
    }
}
