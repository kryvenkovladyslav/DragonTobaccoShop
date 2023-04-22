﻿using Abstractions.Models;
using AbstractionsTests.Common;
using Xunit;

namespace AbstractionsTests.ModelsTests
{
    public sealed class RiviewModelTests
    {
        [Theory]
        [InlineData("Text")]
        public void ReviewItemHasStringPropertyText(string propertyName)
        {
            var targetType = typeof(IReviewModel<>);

            var propertyType = typeof(string);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Evaluation")]
        public void ReviewItemHasIntegerPropertyEvaluation(string propertyName)
        {
            var targetType = typeof(IReviewModel<>);

            var propertyType = typeof(int);

            var result = TestsHelper.TypeHasPropertyWithRequiredTypeAndName(targetType, propertyType, propertyName);

            Assert.True(result);
        }
    }
}