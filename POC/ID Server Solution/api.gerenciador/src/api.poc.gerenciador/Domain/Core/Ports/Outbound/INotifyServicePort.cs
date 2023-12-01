using Domain.Core.Base;

namespace Domain.Core.Ports.Outbound
{
    public interface INotifyServicePort
    {

        Task<BaseReturn> SendEmail(string emailaccount, string subject, string information);
    }
}
