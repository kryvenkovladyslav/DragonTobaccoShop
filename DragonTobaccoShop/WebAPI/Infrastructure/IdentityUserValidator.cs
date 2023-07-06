using Domain.ApplicationModels;
using IdentitySystem.Extensions;
using IdentitySystem.Infrastucture.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure
{
    public sealed class IdentityUserValidator : UserValidator<User, Guid>
    {
        private readonly IdentityErrorDescriber errorDescriber;
        public IdentityUserValidator(IdentityErrorDescriber errorDescriber) : base(errorDescriber) { }

        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            var baseResult = await base.ValidateAsync(manager, user);

            var erros = baseResult.Succeeded ? new List<IdentityError>() : baseResult.Errors.ToList();
            var userYears = DateTime.Now.Year - user.BirthDay.Year;
            if (userYears < 18)
            {
                erros.Add(errorDescriber.YearLessThenEighteen());
            }

            return erros.Count() == 0 ? IdentityResult.Success : IdentityResult.Failed(erros.ToArray());
        }
    }
}