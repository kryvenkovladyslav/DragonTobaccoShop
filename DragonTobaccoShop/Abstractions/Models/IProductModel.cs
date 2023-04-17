namespace Abstractions.Models
{
    internal interface IProductModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }  
        public bool IsAvailable { get; set; }
        public int Discount { get; set; }
        public string ImagePath { get; set; }
    }
}