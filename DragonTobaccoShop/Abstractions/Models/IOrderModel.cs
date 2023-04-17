namespace Abstractions.Models
{
    public interface IOrderModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public string Status { get; set; }
        public decimal TototalPrice { get; set; }
    }
}