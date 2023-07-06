using IdentitySystem.Infrastucture.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Services.Implementation
{
    public class UserRoleManager<TUser, TRole, TKey> : IUserRoleManager<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole: IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly UserManager<TUser> userManager;
        private readonly RoleManager<TRole> roleManager;

        public UserRoleManager(UserManager<TUser> userManager, RoleManager<TRole> roleManager) 
        { 
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

         public virtual async Task<bool> IsUserInRoleAsync(TUser user, TRole role)
         {
             return await userManager.IsInRoleAsync(user, role.Name);
         }

         public virtual async Task<IEnumerable<string>> GetAllRolesNameForUserAsync(TUser user)
         {
             return await userManager.GetRolesAsync(user);
         }

         public virtual async Task<IdentityResult> AddUserToRoleAsync(TUser user, TRole role)
         {
             return await userManager.AddToRoleAsync(user, role.Name); 
         }

         public virtual async Task<IdentityResult> DeleteUserFromRoleAsync(TUser user, TRole role)
         {
             return await userManager.RemoveFromRoleAsync(user, role.Name);
         }
    }
}