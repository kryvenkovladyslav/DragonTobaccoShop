using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Services.Interfaces
{
    public interface IUserService<TUser, TKey>
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<TUser> FindUserByEmailAsync(string email);

        public Task<TUser> FindUserByNamelAsync(string userName);

        public Task<TUser> FindUserByPredicateAsync(Expression<Func<TUser, bool>> predicate);

        public Task<IEnumerable<TUser>> GetAllUsersByPredicateAsync(Expression<Func<TUser, bool>> predicate);

        public Task<IEnumerable<TUser>> GetAllUsersAsync();

        public Task<IdentityResult> ChangeUserNameAsync(TUser user, string userName);

        public Task<IdentityResult> CreateNewUserAsync(TUser user, string currentPassword);
        public Task<bool> CheckPasswordAsync(TUser user, string password);
    }
}