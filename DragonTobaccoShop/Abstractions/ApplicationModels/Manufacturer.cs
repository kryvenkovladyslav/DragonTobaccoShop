using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Manufacturer
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string ImagePath { get; set; }

        public virtual ICollection<Tobacco> Tobaccos { get; set; }
    }
}