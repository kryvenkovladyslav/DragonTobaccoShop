namespace WebAPI.Infrastructure.Options
{
    public sealed class OriginsOptions
    {
        public const string Position = "Client";

        public string Url { get; set; } = string.Empty;
    }
}