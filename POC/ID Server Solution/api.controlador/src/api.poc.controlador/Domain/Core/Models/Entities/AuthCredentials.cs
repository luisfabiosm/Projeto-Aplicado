namespace Domain.Core.Models.Entities
{
    public record AuthCredentials
    {
        public string GrantType { get; internal set; }
        public string ClientId { get; internal set; }
        public string Username { get; internal set; }
        public string Password { get; internal set; }
        public string Secret { get; internal set; }
        public List<string> Scopes { get; internal set; }

        ~AuthCredentials()
        {
            GrantType = null;
            ClientId = null;
            Username = null;
            Password = null;
        }
    }
}
