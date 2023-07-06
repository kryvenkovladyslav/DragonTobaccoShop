using IdentitySystem.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySystem.Infrastucture.Validation
{
    public class PassowrdValidator<TUser, TKey> : PasswordValidator<TUser>, IPasswordValidator<TUser> 
        where TUser : IdentityUser<TKey> 
        where TKey : IEquatable<TKey>
    {
        private readonly IdentityErrorDescriber errorDescriber;

        public PassowrdValidator(IdentityErrorDescriber errorDescriber)
        {
            this.errorDescriber = errorDescriber;
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            var baseResult = await base.ValidateAsync(manager, user, password);

            var erros = baseResult.Succeeded ? new List<IdentityError>() : baseResult.Errors.ToList();

            if (ValidatePasswordForUserName(password, user.UserName))
            {
                erros.Add(errorDescriber.PasswordContainsUserName());
            }
            if (ValidatePasswordForNumericSequence(password))
            {
                erros.Add(errorDescriber.PasswordContainsNumericSequence());
            }

            return erros.Count() == 0 ? IdentityResult.Success : IdentityResult.Failed(erros.ToArray());
        }

        private bool ValidatePasswordForNumericSequence(string password)
        {
            return password.Contains("123") || password.Contains("123456");
        }

        private bool ValidatePasswordForUserName(string password, string userName)
        {
            return password.ToLower().Contains(userName);
        }
    }
}