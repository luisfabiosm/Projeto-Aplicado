namespace Domain.Core.Models.Settings
{
    public record IdentityServerSettings
    {
        public TokenSettings Token { get; set; }
    }


    public struct TokenSettings
    {
        public string Endpoint { get; set; }
    }
}
