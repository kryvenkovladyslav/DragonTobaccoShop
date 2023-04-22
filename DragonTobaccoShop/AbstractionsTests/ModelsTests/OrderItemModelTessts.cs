using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class OrderItemModelTessts : BaseTests
    {
        [Theory]
        [InlineData("Count")]
        public void OrderItemHasIntegerPropertyCount(string count)
        {
            var targetType = typeof(IOrderItem<>);

            var propertyType = typeof(int);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, count);

            Assert.True(result);
        }
    }
}