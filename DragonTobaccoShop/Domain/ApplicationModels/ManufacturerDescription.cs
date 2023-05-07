using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class ManufacturerDescription : IDesctiptionModel<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual string Path { get; set; }

        public virtual Guid ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }  
    }
}