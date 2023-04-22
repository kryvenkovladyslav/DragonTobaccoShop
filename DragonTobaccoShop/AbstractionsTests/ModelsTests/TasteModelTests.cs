using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class TasteModelTests
    {
        [Theory]
        [InlineData("Name")]
        public void TasteHasStringPropertyName(string propertyName)
        {
            var targetType = typeof(ITasteModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}