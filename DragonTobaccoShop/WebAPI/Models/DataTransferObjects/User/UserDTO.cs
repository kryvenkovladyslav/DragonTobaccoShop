using System;

namespace WebAPI.Models.DataTransferObjects.User
{
    public sealed class UserDTO
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string AccountImagePath { get; set; }
        public DateTime RegistraionDate { get; set; }
    }
}