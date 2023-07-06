using System;

namespace WebAPI.Models.ViewModel
{
    public sealed class WishListProductCreation
    {
        public Guid ProductID { get; set; }
        public Guid WishListID { get; set; }
    }
}