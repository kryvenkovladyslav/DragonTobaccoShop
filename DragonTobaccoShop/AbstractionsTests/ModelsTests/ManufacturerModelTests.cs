using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class ManufacturerModelTests : BaseTests
    {
        [Theory]
        [InlineData("Name")]
        public void ManufacturerHasStringPropertyName(string propertyName)
        {
            var targetType = typeof(IManufacturerModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ImagePath")]
        public void ManufacturerHasStringPropertyImagePath(string propertyName)
        {
            var targetType = typeof(IManufacturerModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}