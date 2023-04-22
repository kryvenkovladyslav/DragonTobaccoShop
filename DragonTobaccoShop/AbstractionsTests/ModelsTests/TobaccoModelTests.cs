using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class TobaccoModelTests : BaseTests
    {
        [Theory]
        [InlineData("Name")]
        public void TobaccoHasStringPropertyName(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Weight")]
        public void TobaccoHasDoublePropertyWeigth(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(double);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Leaf")]
        public void TobaccoHasStringPropertyLeaf(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Package")]
        public void TobaccoHasStringPropertyPackage(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Slicing")]
        public void TobaccoHasStringPropertySlicing(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Country")]
        public void TobaccoHasStringPropertyCountry(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("IsSmoky")]
        public void TobaccoHasBooleanPropertyIsSmoky(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(bool);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("IsMixed")]
        public void TobaccoHasBooleanPropertyIsMixed(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(bool);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("IsMint")]
        public void TobaccoHasBooleanPropertyIsMint(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(bool);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("IsSweet")]
        public void TobaccoHasBooleanPropertyIsSweet(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(bool);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("IsIced")]
        public void TobaccoHasBooleanPropertyIsIced(string propertyName)
        {
            var targetType = typeof(ITobaccoModel<>);

            var propertyType = typeof(bool);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}