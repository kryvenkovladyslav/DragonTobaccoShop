using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Tobacco
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual double Weight { get; set; }
        public virtual string Leaf { get; set; }
        public virtual string Package { get; set; }
        public virtual string Slicing { get; set; }
        public virtual string Country { get; set; }
        public virtual bool IsSmoky { get; set; }
        public virtual bool IsMixed { get; set; }
        public virtual bool IsMint { get; set; }
        public virtual bool IsSweet { get; set; }
        public virtual bool IsIced { get; set; }

        public virtual Guid? ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Guid? StrengthID { get; set; }
        public virtual Strength Strength { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<TobaccosTastes> Tastes { get; set; }
    }
}