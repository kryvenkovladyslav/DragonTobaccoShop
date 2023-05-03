using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Description : IDesctiptionModel<Guid>
    {
        public Guid ID { get; set; }
        public string Path { get; set; }

        public Guid ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public Guid TobaccoID { get; set; }
        public Tobacco Tobacco { get; set; }    
    }
}