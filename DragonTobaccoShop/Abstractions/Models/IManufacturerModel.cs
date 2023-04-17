namespace Abstractions.Models
{
    public  interface IManufacturerModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}