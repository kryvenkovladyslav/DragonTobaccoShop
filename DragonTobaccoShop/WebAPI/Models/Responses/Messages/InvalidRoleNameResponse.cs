using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public class InvalidRoleNameResponse : IResponse
    {
        public string Description { get; } = "Invaild role name";
    }
}
