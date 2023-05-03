using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class CartSession : ICartSessionModel<Guid>
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } 
    }
}