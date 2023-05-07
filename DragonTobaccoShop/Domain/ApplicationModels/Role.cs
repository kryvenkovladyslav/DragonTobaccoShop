using Abstractions.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Role : IdentityRole<Guid>, IRoleModel<Role> 
    {
        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}