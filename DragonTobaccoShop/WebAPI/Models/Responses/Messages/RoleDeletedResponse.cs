using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class RoleDeletedResponse : IResponse
    {
        public string Description { get; } = "You have been deleted a role successfuly";
    }
}