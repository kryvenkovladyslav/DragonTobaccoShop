using Microsoft.AspNetCore.Identity;

namespace Abstractions.Models
{
    public interface IUserModel<TUser> where TUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string AccountImagePath { get; set; }
        public DateTime RegistraionDate { get; set; }
    }
}