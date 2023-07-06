using System;
using WebAPI.Models.DataTransferObjects.Tobacco;

namespace WebAPI.Models.DataTransferObjects.Product
{
    public sealed class MainProduct
    {
        public Guid ID { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Discount { get; set; }
        public string ImagePath { get; set; }
        public TobaccoDTO Tobacco { get; set; }
    }
}
