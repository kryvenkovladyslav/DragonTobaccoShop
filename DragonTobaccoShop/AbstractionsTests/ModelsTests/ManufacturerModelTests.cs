using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class ManufacturerModelTests : BaseTests
    {
        [Theory]
        [InlineData("Name")]
        public void ManufacturerModelHasStringPropertyName(string name)
        {
            var targetType = typeof(IManufacturerModel<>);

            var propertyType = name.GetType();

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, name);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ImagePath")]
        public void ManufacturerModelHasStringPropertyImagePath(string imagePath)
        {
            var targetType = typeof(IManufacturerModel<>);

            var propertyType = imagePath.GetType();

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, imagePath);

            Assert.True(result);
        }
    }
}