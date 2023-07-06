using System;

namespace JWTAuthentification.Common.Data
{
    public sealed class JWTToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}