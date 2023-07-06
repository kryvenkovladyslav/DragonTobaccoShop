namespace JWTAuthentification.Common.Options
{
    public interface IJWTAuthenticationOptions
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
    }
}