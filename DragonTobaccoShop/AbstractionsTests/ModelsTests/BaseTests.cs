using Abstractions.Models;
using System;
using System.Linq;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public  class BaseTests
    {
        [Fact]
        public virtual void IsGenericType()
        {
            Assert.True(typeof(ICartSessionModel<>).IsGenericType);
        }

        [Fact]
        public virtual void TypeHasValueTypeConstraint()
        {
            var typeConstraint = typeof(ICartSessionModel<>).GetGenericArguments().First()
                .GetGenericParameterConstraints().FirstOrDefault();

            Assert.Equal(typeof(ValueType), typeConstraint);
        }

        [Theory]
        [InlineData("ID")]
        public virtual void TypeHasPropertyID(string id)
        {
            var requiredProperty = typeof(ICartSessionModel<>).GetProperties()
                .Where(p => p.Name == id).FirstOrDefault();

            Assert.Contains(id, requiredProperty?.Name);
        }

        [Theory]
        [InlineData("ID")]
        public virtual void TypeHasGenericPropertyID(string id)
        {
            var requiredProperty = typeof(ICartSessionModel<>).GetProperties()
                .Where(p => p.PropertyType.IsGenericTypeParameter && p.Name == id).FirstOrDefault();

            Assert.True(requiredProperty != null);
        }
    }
}