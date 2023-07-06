using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public class ModelUpdatedResponse : IResponse
    {
        public string Description { get; }
        
        public ModelUpdatedResponse(string modelType)
        {
            Description = $"{modelType} has been updated successfuly";
        }
    }
}