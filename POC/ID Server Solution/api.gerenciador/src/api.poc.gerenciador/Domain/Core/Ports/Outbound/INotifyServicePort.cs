namespace Domain.Core.Ports.Outbound
{
    public interface INotifyServicePort
    {

        Task<string> SendEmail(string emailaccount, string subject, string information);
    }
}
