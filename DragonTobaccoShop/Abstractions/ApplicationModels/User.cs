using Abstractions.ApplicationModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class User : IdentityUser<Guid>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDay { get; set; }
        public virtual string AccountImagePath { get; set; }
        public virtual DateTime RegistraionDate { get; set; }

        public virtual WishList WishList { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<CartSession> CartSessions { get; set; } 
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<CheckedProduct> CheckedProducts { get; set; }

        public User() 
        {
            RegistraionDate = DateTime.Now;
        }
    }
}