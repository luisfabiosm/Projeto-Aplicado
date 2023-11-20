namespace TesteKeycloak.net.Models
{
    public record AccessTokenRequest
    {

        public string ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
    }
}
