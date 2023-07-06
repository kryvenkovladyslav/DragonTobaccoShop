using WebAPI.Models.Responses.Interfaces;

namespace WebAPI.Models.Responses.Messages
{
    public sealed class ManufacturerCreatedResponse : IResponse
    {
        public string Description { get; } = "Manufaturer has been created successfuly";
    }
}