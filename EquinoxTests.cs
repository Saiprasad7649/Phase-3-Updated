using System;
using Xunit;
using Equinox.Models;

namespace Equinox.Tests
{
    public class EquinoxTests
    {
        [Fact]
        public void SampleTest()
        {
            // Arrange
            int expected = 2;
            int actual = 1 + 1;

            // Act & Assert
            Assert.Equal(expected, actual);
        }
    }
}
