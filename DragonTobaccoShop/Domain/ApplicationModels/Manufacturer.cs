using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Manufacturer : IManufacturerModel<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Tobacco> Tobaccos { get; set; }
        public ICollection<Description> Descriptions { get; set; }
    }
}