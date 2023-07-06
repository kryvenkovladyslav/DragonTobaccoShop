using Domain.ApplicationModels;
using System;
using System.Collections.Generic;

namespace Abstractions.Models
{
    public class Product : ProductModel<Guid>
    {
        public virtual Guid? WishListID { get; set; }
        public virtual WishList WishList { get; set; }
        public virtual Tobacco Tobacco { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<CheckedProduct> CheckedProducts { get; set; }
    }
}