namespace Domain.Core.Models.Settings
{
    public record IdentitySettings
    {
        public TokenSettings Token { get; set; }
    }


    public struct TokenSettings
    {
        public string Endpoint { get; set; }
    }
}
