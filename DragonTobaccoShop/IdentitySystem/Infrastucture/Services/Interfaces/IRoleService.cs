using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Services.Interfaces
{
    public interface IRoleService<TRole, TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<IdentityResult> CreateNewRoleAsync(TRole role);

        public Task<IdentityResult> UpdateRoleAsync(TRole role);

        public Task<IdentityResult> DeleteRoleAsync(TRole role);

        public Task<TRole> FindByNameAsync(string roleName);

        public Task<IEnumerable<TRole>> GetAllRolesAsync();
    }
}