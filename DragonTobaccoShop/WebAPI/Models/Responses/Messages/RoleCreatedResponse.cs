using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public class RoleCreatedResponse : IResponse
    {
        public string Description { get; } = "You have created a role successfuly";
        public bool IsCreated { get; } = true;
    }
}