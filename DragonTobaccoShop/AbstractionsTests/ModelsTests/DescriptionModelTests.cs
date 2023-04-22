using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class DescriptionModelTests : BaseTests
    {
        [Theory]
        [InlineData("Path")]
        public void DescriptionHasStringPropertyPath(string propertyName)
        {
            var targerType = typeof(IDesctiptionModel<>);

            var propertyType = typeof(string);
            
            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targerType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}