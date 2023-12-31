﻿namespace TesteKeycloak.net.Models
{
    public record AccessTokenResponse
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string Scope { get; set; }
        public string RefreshToken { get; set; }

    }
}
