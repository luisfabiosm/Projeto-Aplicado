using Domain.Core.Base;
using Domain.Core.Ports.Outbound;

namespace Adapters.Outbound.NotifyAdapter
{
    public class NotifyServicePort : INotifyServicePort
    {

        public NotifyServicePort()
        {

        }
        public async Task<BaseReturn> SendEmail(string emailaccount, string subject, string information)
        {
            return new BaseReturn("");
        }
    }
}
