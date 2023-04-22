using Abstractions.Models;
using System.Linq;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public class DescriptionModelTests : BaseTests
    {
        [Theory]
        [InlineData("Path")]
        public void TypeHasStringPropertyPath(string path)
        {
            var requiredProperty = typeof(IDesctiptionModel<>).GetProperties()
                .Where(p => p.PropertyType == typeof(string) && p.Name == path);

            Assert.NotNull(requiredProperty);
        }
    }
}