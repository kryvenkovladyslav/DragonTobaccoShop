using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class InvalidUserNameResponse : IResponse
    {
        public string Description { get; } = "Invaild username";
    }
}