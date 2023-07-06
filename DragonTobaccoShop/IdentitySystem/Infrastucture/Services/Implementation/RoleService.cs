using IdentitySystem.Infrastucture.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Services.Implementation
{
    public class RoleService<TRole, TKey> : IRoleService<TRole, TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly RoleManager<TRole> roleManager;

        public RoleService(RoleManager<TRole> roleManager)
        {
            this.roleManager = roleManager;
        }
            
        public virtual async Task<IdentityResult> CreateNewRoleAsync(TRole role)
        {
            return await roleManager.CreateAsync(role);
        }

        public virtual async Task<IdentityResult> UpdateRoleAsync(TRole role)
        {
            return await roleManager.UpdateAsync(role);
        }

        public virtual async Task<IdentityResult> DeleteRoleAsync(TRole role)
        {
            return await roleManager.DeleteAsync(role);
        }

        public virtual async Task<TRole> FindByNameAsync(string roleName)
        {
            return await roleManager.FindByNameAsync(roleName);
        }

        public virtual async Task<IEnumerable<TRole>> GetAllRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }
    }
}