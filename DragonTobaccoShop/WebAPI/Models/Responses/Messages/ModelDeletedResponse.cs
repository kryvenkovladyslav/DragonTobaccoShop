using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public class ModelDeletedResponse : IResponse
    {
        public string Description { get; }

        public ModelDeletedResponse(string modelType)
        {
            Description = $"{modelType} has been deleted successfuly";
        }
    }
}