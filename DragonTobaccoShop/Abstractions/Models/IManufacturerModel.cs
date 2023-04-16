namespace Abstractions.Models
{
    public  interface IManufacturerModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}