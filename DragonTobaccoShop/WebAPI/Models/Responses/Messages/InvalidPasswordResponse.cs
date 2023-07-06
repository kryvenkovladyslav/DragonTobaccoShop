using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class InvalidPasswordResponse : IResponse
    {
        public string Description { get; } = "Invaild password";
    }
}