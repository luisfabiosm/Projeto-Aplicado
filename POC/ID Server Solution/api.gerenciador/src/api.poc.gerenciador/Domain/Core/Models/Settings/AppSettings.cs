namespace Domain.Core.Models.Settings
{
    public record AppSettings
    {
        public ConnectionSettings DBSettings { get; set; }

        public IdentityServerSettings IdentitySettings { get; set; }

        public NotifySettings EmailSettings { get; set; }

    }
}
