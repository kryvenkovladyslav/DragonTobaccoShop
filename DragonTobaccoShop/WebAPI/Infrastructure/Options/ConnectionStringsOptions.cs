namespace WebAPI.Infrastructure.Options
{
    public sealed class ConnectionStringsOptions
    {
        public const string Position = "ConnectionStrings";

        public string ApplicationConnetion { get; set; } = string.Empty;
    }
}