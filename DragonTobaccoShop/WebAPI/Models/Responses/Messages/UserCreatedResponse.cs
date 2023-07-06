using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class UserCreatedResponse : IResponse
    {
        public string Description { get; } = "You have been registered successfuly";
        public bool IsRegistered { get; } = true;
    }
}