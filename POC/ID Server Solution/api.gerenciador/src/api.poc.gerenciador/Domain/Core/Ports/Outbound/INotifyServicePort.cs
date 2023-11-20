namespace Domain.Core.Ports.Outbound
{
    public interface INotifyServicePort
    {

        Task SendEmail(string emailaccount, string subject, string information);
    }
}
