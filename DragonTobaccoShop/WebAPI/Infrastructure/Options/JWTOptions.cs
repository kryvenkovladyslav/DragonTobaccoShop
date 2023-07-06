using JWTAuthentification.Common.Options;

namespace WebAPI.Infrastructure.Options
{
    public sealed class JWTOptions : IJWTAuthenticationOptions
    {
        public const string Position = "JWTAuthentication";

        public string ValidAudience { get; set; } = string.Empty;
        public string ValidIssuer { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
    }
}