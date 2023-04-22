using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class StrengthModelState
    {
        [Theory]
        [InlineData("Kind")]
        public void OrderItemHasStringPropertyText(string propertyName)
        {
            var targetType = typeof(IStengthModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}