

namespace Domain.Core.Models.Entities
{
    public record Operator : IDisposable
    {
        public string User { get; internal set; }
        public string Password { get; internal set; }
        public AuthCredentials? Credentials { get; internal set; }
        public int? ExpirationSeconds { get; internal set; }
        public string? KeycloakSerializedInfo { get; internal set; }
        public bool ForceChange { get; internal set; }

        public DateTime? LastUpdate { get; internal set; }

        public Operator(string user, string password)
        {
            User = user;
            Password = password;
        }


        public void Dispose()
        {
            User = null;
            LastUpdate = null;
            Password = null;
            ExpirationSeconds = null;
            KeycloakSerializedInfo = null;

        }
    }
}
