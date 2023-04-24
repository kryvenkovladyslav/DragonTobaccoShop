using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class Order : IOrderModel<Guid>
    {
        public Guid ID { get; set; }
        public string Status { get; set; }
        public decimal TototalPrice { get; set; }
    }
}