using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Tobacco : ITobaccoModel<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Leaf { get; set; }
        public string Package { get; set; }
        public string Slicing { get; set; }
        public string Country { get; set; }
        public bool IsSmoky { get; set; }
        public bool IsMixed { get; set; }
        public bool IsMint { get; set; }
        public bool IsSweet { get; set; }
        public bool IsIced { get; set; }

        public Guid ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Guid StrengthID { get; set; }
        public Strength Strength { get; set; }
        public Product Product { get; set; }
        public ICollection<Description> Descriptions { get; set; }
        public ICollection<TobaccosTastes> Tastes { get; set; }
    }
}