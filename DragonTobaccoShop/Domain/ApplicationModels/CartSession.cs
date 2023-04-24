using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class CartSession : ICartSessionModel<Guid>
    {
        public Guid ID { get; set; }
    }
}