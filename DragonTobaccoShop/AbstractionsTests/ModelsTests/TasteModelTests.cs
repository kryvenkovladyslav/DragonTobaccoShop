﻿using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class TasteModelTests
    {
        [Theory]
        [InlineData("Name")]
        public void TasteItemHasStringPropertyName(string propertyName)
        {
            var targetType = typeof(IReviewModel<>);

            var propertyType = typeof(int);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}