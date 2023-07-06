using Abstractions.Common;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace WebAPI.Infrastructure.Attributes
{
    public sealed class AuthorizeRole : AuthorizeAttribute
    {
        public AuthorizeRole(params ApplicationRoles[] roles)
        {
            var allowedRolesAsStrings = roles.Select(x => Enum.GetName(typeof(ApplicationRoles), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}