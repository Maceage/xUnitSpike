using FluentAssertions;
using Xunit;

namespace xUnitSpike.Services.UnitTests
{
    public class MyFirstTheory
    {
        [Theory]
        [InlineData(3, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        public void IsOdd_WithNumbers_IsExpected(int number, bool expected)
        {
            // Act
            bool isOdd = IsOdd(number);

            // Assert
            isOdd.Should().Be(expected);
        }

        private static bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}