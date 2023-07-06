using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Services.Interfaces
{
    public interface IUserRoleManager<TUser, TRole, TKey> 
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<bool> IsUserInRoleAsync(TUser user, TRole role);

        public Task<IdentityResult> AddUserToRoleAsync(TUser user, TRole role);

        public Task<IdentityResult> DeleteUserFromRoleAsync(TUser user, TRole role);

        public Task<IEnumerable<string>> GetAllRolesNameForUserAsync(TUser user);
    }
}