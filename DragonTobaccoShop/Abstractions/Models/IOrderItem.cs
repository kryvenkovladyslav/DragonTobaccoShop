namespace Abstractions.Models
{
    public interface IOrderItem
    {
        public Guid ID { get; set; }
        public int Count { get; set; }
    }
}