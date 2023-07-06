using System.Collections.Generic;
using System;
using WebAPI.Models.DataTransferObjects.Tobacco;

namespace WebAPI.Models.DataTransferObjects.Manufacturer
{
    public sealed class ManufacturerWithTobaccoDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public ICollection<TobaccoDTO> Tobaccos { get; set; }
    }
}