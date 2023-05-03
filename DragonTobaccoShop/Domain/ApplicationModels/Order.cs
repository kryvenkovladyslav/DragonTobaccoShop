using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Order : IOrderModel<Guid>
    {
        public Guid ID { get; set; }
        public string Status { get; set; }
        public decimal TototalPrice { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; } 

        public ICollection<OrderItem> Items { get; set; }
    }
}