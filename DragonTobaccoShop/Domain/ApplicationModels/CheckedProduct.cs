using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class CheckedProduct : ICheckedProduct<Guid>
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }  
        public Product Product { get; set; }
    }
}