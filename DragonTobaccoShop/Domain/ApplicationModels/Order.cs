using Abstractions.Common;
using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Order : IOrderModel<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual decimal TototalPrice { get; set; }

        public virtual Guid UserID { get; set; }
        public virtual User User { get; set; } 

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}