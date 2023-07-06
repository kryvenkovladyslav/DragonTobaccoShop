using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public class ModelNotExistResponse : IResponse
    {
        public string Description { get; }

        public ModelNotExistResponse(string modelType)
        {
            Description = $"{modelType} does not exist";
        }
    }
}