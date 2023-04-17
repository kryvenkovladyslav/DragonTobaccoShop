namespace Abstractions.Models
{
    public interface IOrderItem<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public int Count { get; set; }
    }
}