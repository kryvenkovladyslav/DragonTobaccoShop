using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class InvalidObjectResponse : IResponse
    {
        public string Description { get; } = "You should fill the blanks";
    }
}