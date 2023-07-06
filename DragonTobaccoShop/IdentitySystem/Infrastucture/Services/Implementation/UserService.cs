using IdentitySystem.Infrastucture.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Services.Implementation
{
    public class UserService<TUser, TKey> : IUserService<TUser, TKey> 
        where TUser : IdentityUser<TKey> 
        where TKey : IEquatable<TKey>
    {
        private readonly UserManager<TUser> userManager;

        public UserService(UserManager<TUser> userManager)
        {
            this.userManager = userManager;
        }

        public virtual async Task<TUser> FindUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public virtual async Task<TUser> FindUserByNamelAsync(string userName)
        {
            return await userManager.FindByNameAsync(userName);
        }

        public virtual async Task<TUser> FindUserByPredicateAsync(Expression<Func<TUser, bool>> predicate)
        {
            return await userManager.Users.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TUser>> GetAllUsersByPredicateAsync(Expression<Func<TUser, bool>> predicate)
        {
            return await userManager.Users.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TUser>> GetAllUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public virtual async Task<IdentityResult> ChangeUserNameAsync(TUser user, string userName)
        {
            return await userManager.SetUserNameAsync(user, userName);
        }

        public virtual async Task<IdentityResult> CreateNewUserAsync(TUser user, string currentPassword)
        {
            return await userManager.CreateAsync(user, currentPassword);
        }
        public virtual async Task<bool> CheckPasswordAsync(TUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }
    }
}