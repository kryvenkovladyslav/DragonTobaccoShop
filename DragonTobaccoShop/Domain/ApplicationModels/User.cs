using Abstractions.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class User : IdentityUser<Guid>, IUserModel<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string AccountImagePath { get; set; }
        public DateTime RegistraionDate { get; set; }

        public WishList WishList { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CartSession> CartSessions { get; set; } 
        public ICollection<CheckedProduct> CheckedProducts { get; set; }
    }
}