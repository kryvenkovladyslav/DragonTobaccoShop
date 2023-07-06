using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Validation
{
    public class UserValidator<TUser, Tkey> : UserValidator<TUser>, IUserValidator<TUser> 
        where TUser : IdentityUser<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        private readonly IdentityErrorDescriber errorDescriber;

        public UserValidator(IdentityErrorDescriber errorDescriber)
        {
            this.errorDescriber = errorDescriber;
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            var baseResult = await base.ValidateAsync(manager, user);

            var erros = baseResult.Succeeded ? new List<IdentityError>() : baseResult.Errors.ToList();

            if (await manager.FindByEmailAsync(user.Email) != null)
            {
                erros.Add(errorDescriber.DuplicateEmail(user.Email));
            }

            return erros.Count() == 0 ? IdentityResult.Success : IdentityResult.Failed(erros.ToArray());
        }
    }
}