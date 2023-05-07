using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class OrderItem : IOrderItem<Guid>
    {
        public Guid ID { get; set; }
        public int Count { get; set; }

        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public Guid CartSessionID { get; set; }
        public virtual CartSession CartSession { get; set; }
    }
}