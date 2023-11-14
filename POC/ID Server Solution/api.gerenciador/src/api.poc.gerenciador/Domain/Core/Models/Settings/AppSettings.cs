namespace Domain.Core.Models.Settings
{
    public record AppSettings
    {
        public ConnectionSettings DBSettings { get; set; }
        
    }
}
