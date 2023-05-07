using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class CartSession : ICartSessionModel<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual Guid UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } 
    }
}