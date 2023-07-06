using Abstractions.ApplicationModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Role : IdentityRole<Guid>
    {
        public Role(string name): base(name) { }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}