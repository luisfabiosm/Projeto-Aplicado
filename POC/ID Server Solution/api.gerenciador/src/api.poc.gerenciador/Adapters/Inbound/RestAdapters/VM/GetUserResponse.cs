using Domain.Core.Models.Dto;

namespace Adapters.Inbound.RestAdapters.VM
{
    public record GetUserResponse : UserNotify
    {
        public GetUserResponse(string user, string secret): base (user, secret)
        {
            
        }

    }
}
