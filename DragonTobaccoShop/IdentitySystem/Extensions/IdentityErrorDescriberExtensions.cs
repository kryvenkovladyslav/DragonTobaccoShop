using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.Extensions
{
    public static class IdentityErrorDescriberExtensions
    {
        public static IdentityError PasswordContainsUserName(this IdentityErrorDescriber describer)
        {
            return new IdentityError
            {
                Code = nameof(PasswordContainsUserName),
                Description = "Current password connot constain a username"
            };
        }

        public static IdentityError PasswordContainsNumericSequence(this IdentityErrorDescriber describer)
        {
            return new IdentityError
            {
                Code = nameof(PasswordContainsNumericSequence),
                Description = "Current password connot constain numeric sequences like 123..."
            };
        }

        public static IdentityError RequiredFieldIsEmpty(this IdentityErrorDescriber describer)
        {
            return new IdentityError
            {
                Code = nameof(PasswordContainsNumericSequence),
                Description = "This field should be filled..."
            };
        }

        public static IdentityError YearLessThenEighteen(this IdentityErrorDescriber describer)
        {
            return new IdentityError
            {
                Code = nameof(YearLessThenEighteen),
                Description = "You cannot register. You are less than 18 years old"
            };
        }
    }
}