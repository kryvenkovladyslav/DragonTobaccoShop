using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class ProductModelTests : BaseTests
    {

        [Theory]
        [InlineData("Price")]
        public void ProductModelHasDecimalPropertyPrice(string propertyName)
        {
            var targetType = typeof(IProductModel<>);

            var propertyType = typeof(decimal);
                
            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Rating")]
        public void ProductModelHasDoublePropertyRaiting(string propertyName)
        {
            var targetType = typeof(IProductModel<>);

            var propertyType = typeof(double);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("IsAvailable")]
        public void ProductModelHasBooleandPropertyIsAvailable(string propertyName)
        {
            var targetType = typeof(IProductModel<>);

            var propertyType = typeof(bool);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Discount")]
        public void ProductModelHasIntegerPropertyDiscount(string propertyName)
        {
            var targetType = typeof(IProductModel<>);

            var propertyType = typeof(int);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ImagePath")]
        public void ProductModelHasStringPropertyImagePath(string propertyName)
        {
            var targetType = typeof(IProductModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}