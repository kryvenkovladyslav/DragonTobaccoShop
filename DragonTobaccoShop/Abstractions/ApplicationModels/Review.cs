using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class Review
    {
        public virtual Guid ID { get; set; }
        public virtual string Text { get; set; }
        public virtual int Evaluation { get; set; }

        public virtual Guid UserID { get; set; }
        public virtual User User { get; set; }

        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}