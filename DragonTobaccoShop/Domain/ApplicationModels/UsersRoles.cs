using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.ApplicationModels
{
    public class UsersRoles : IdentityUserRole<Guid>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}