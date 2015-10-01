using System;
using FluentAssertions;
using Xunit;

namespace xUnitSpike.Services.UnitTests
{
    public class MyFirstUnitTests
    {
        [Fact]
        public void PassingTest_WithNumbers_PassesTest()
        {   
            // Act
            int result = Add(2, 2);

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public void FailingTest_WithNumbers_FailsTest()
        {
            // Act
            int result = Add(2, 2);

            // Assert
            result.Invoking(r => result.Should().Be(5)).ShouldThrow<Exception>();
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
