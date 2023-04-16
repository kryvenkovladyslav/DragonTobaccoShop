namespace Abstractions.Models
{
    internal interface IProductModel
    {
        public Guid ID { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }  
        public bool IsAvailable { get; set; }
        public int Discount { get; set; }
        public string ImagePath { get; set; }
    }
}