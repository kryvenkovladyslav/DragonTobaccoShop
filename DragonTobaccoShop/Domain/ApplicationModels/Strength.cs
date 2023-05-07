using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Strength : IStengthModel<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual string Kind { get; set; }
        
        public virtual ICollection<Tobacco> Tobaccos { get; set; }
    }
}