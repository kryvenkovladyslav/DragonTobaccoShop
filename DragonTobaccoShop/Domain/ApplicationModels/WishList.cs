using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class WishList : IWishListModel<Guid>
    {
        public Guid ID { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}