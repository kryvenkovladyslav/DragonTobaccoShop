using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class Manufacturer : IManufacturerModel<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}