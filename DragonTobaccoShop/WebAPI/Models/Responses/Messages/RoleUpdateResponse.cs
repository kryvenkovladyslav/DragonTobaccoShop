using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class RoleUpdateResponse : IResponse
    {
        public string Description { get; } = "You have updated a role successfuly";
        public bool IsUpdated { get; } = true;
    }
}