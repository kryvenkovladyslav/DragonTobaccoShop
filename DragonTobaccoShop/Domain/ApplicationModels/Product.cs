using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Product : IProductModel<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual decimal Price { get; set; }
        public virtual double Rating { get; set; }
        public virtual bool IsAvailable { get; set; }
        public virtual int Discount { get; set; }
        public virtual string ImagePath { get; set; }

        public virtual Guid? WishListID { get; set; }
        public virtual WishList WishList { get; set; }
        public virtual Tobacco Tobacco { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<CheckedProduct> CheckedProducts { get; set; }
    }
}