using System;

namespace WebAPI.Models.DataTransferObjects.Product
{
    public sealed class CheckedProductDTO
    {
        public DateTime Date { get; set; }
        public Guid ProductID { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
    }
}