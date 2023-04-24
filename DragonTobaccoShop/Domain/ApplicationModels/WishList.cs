using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class WishList : IWishListModel<Guid>
    {
        public Guid ID { get; set; }
    }
}