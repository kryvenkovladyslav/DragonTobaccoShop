using System;

namespace WebAPI.Models.DataTransferObjects.Product
{
    public sealed class CheckedProductCreationDTO
    {
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
    }
}