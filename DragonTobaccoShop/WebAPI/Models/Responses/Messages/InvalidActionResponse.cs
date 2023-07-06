using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class InvalidActionResponse : IResponse
    {
        public string Description { get; } = "Invaild action...Retry";
    }
}