using WebAPI.Models.DataTransferObjects.Tobacco;

namespace WebAPI.Models.DataTransferObjects.Product
{
    public class ProductCreationDTO
    {
        public virtual decimal Price { get; set; }
        public virtual double Rating { get; set; }
        public virtual bool IsAvailable { get; set; }
        public virtual int Discount { get; set; }
        public virtual string ImagePath { get; set; }

        public virtual TobaccoDTO Tobacco { get; set; }
    }
}
