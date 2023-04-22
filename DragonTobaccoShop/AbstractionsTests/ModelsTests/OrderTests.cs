using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class OrderTests : BaseTests
    {
        [Theory]
        [InlineData("Status")]
        public void OrderHasStringPropertyStatus(string propertyName)
        {
            var targetType = typeof(IOrderModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("TototalPrice")]
        public void OrderHasDeciamlPropertyTototalPrice(string propertyName)
        {
            var targetType = typeof(IOrderModel<>);

            var propertyType = typeof(decimal);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}