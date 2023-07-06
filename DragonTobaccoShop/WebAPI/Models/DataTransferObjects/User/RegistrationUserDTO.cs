using IdentitySystem.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DataTransferObjects.User
{
    public sealed class RegistrationUserDTO
    {
        public string UserName { get; set; }

       
        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
    }
}