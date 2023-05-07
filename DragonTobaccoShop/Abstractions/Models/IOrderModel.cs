using Abstractions.Common;

namespace Abstractions.Models
{
    public interface IOrderModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TototalPrice { get; set; }
    }
}