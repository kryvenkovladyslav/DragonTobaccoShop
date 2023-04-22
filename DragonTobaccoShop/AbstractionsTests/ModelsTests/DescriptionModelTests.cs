using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class DescriptionModelTests : BaseTests
    {
        [Theory]
        [InlineData("Path")]
        public void DescriptionHasStringPropertyPath(string path)
        {
            var targerType = typeof(IDesctiptionModel<>);
            var propertyType = path.GetType();
            
            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targerType, propertyType, path);

            Assert.True(result);
        }
    }
}