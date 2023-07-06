using Abstractions.Common;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Strength
    {
        public virtual Guid ID { get; set; }
        public virtual StrengthKind Kind { get; set; }
        
        public virtual ICollection<Tobacco> Tobaccos { get; set; }
    }
}