using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class OrderItemModelTessts : BaseTests
    {
        [Theory]
        [InlineData("Count")]
        public void OrderItemHasIntegerPropertyCount(string propertyName)
        {
            var targetType = typeof(IOrderItem<>);

            var propertyType = typeof(int);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}