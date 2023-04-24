using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class OrderItem : IOrderItem<Guid>
    {
        public Guid ID { get; set; }
        public int Count { get; set; }
    }
}