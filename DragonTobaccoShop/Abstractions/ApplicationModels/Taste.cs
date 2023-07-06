using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Taste
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<TobaccosTastes> Tobaccos { get; set; }
    }
}