using Abstractions.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.ApplicationModels
{
    public class User : IdentityUser<Guid>, IUserModel<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string AccountImagePath { get; set; }
        public DateTime RegistraionDate { get; set; }
    }
}