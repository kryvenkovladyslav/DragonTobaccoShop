using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class CheckedProduct : ICheckedProduct<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Guid UserID { get; set; }
        public virtual User User { get; set; }  
        public virtual Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}