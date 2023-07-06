using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public class UserAddToRoleResponse : IResponse
    {
        public string Description { get; }
        public bool IsAdded { get; } = true;

        public UserAddToRoleResponse(string userName, string roleName)
        {
            Description = $"You have added {userName} to {roleName} role successfuly";
        }
    }
}