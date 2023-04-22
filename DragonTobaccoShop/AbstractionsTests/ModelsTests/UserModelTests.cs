using Abstractions.Models;
using AbstractionsTests.Common;
using System;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class UserModelTests
    {
        [Theory]
        [InlineData("FirstName")]
        public void UserHasStringPropertyFirstName(string propertyName)
        {
            var targerType = typeof(IUserModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targerType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("LastName")]
        public void UserHasStringPropertyLastName(string propertyName)
        {
            var targerType = typeof(IUserModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targerType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("AccountImagePath")]
        public void UserHasStringPropertyAccountImagePath(string propertyName)
        {
            var targerType = typeof(IUserModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targerType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("BirthDay")]
        public void UserHasDateTimePropertyBirthDay(string propertyName)
        {
            var targerType = typeof(IUserModel<>);

            var propertyType = typeof(DateTime);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targerType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("RegistraionDate")]
        public void UserHasDateTimePropertyRegistraionDate(string propertyName)
        {
            var targerType = typeof(IUserModel<>);

            var propertyType = typeof(DateTime);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targerType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}