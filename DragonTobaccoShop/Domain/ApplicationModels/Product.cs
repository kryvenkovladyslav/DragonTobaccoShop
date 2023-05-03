using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Product : IProductModel<Guid>
    {
        public Guid ID { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }
        public int Discount { get; set; }
        public string ImagePath { get; set; }

        public Guid WishListID { get; set; }
        public WishList WishList { get; set; }
        public Tobacco Tobacco { get; set; }
        public OrderItem OrderItem { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}