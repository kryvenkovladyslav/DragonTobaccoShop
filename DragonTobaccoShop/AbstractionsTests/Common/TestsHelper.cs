using System;
using System.Linq;

namespace AbstractionsTests.Common
{
    public static class TestsHelper
    {
        public static bool TypeHasPropertyWithRequiredTypeAndName(Type targetType, Type propertyType, string propertyName)
        {

            var requiredProperty = targetType.GetProperties()
                .Where(p => p.PropertyType == propertyType && p.Name == propertyName).FirstOrDefault();

            return requiredProperty != null;
        }
    }
}