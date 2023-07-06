using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class ModelAlreadyExistResponse : IResponse
    {
        public string Description { get; }
        public ModelAlreadyExistResponse(string name, string entityType) 
        {
            Description = $"{entityType} with {name} is already exist";
        }
    }
}