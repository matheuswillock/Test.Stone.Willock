using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Infrastructure.Library;

namespace Test.Stone.Willock.Tests.Infrastructure.Library
{
    public class OutputUnitTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Act
            var output = new Output();

            // Assert
            Assert.True(output.IsValid);
            Assert.NotNull(output.Messages);
            Assert.NotNull(output.ErrorMessages);
            Assert.Null(output.Result);
            Assert.Empty(output.Messages);
            Assert.Empty(output.ErrorMessages);
        }

        [Fact]
        public void AddResult_SetsResultCorrectly()
        {
            // Arrange
            var output = new Output();
            var result = new { Id = 1, Name = "Test" };

            // Act
            output.AddResult(result);

            // Assert
            Assert.Equal(result, output.Result);
        }

        [Fact]
        public void GetResult_ReturnsResultWhenNotNull()
        {
            // Arrange
            var output = new Output();
            var result = new { Id = 1, Name = "Test" };
            output.AddResult(result);

            // Act
            var actualResult = output.GetResult();

            // Assert
            Assert.Equal(result, actualResult);
        }

        [Fact]
        public void GetResult_ThrowsExceptionWhenResultIsNull()
        {
            // Arrange
            var output = new Output();

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => output.GetResult());
            Assert.Equal("Result is null", exception.Message);
        }

        [Fact]
        public void AddErrorMessage_AddsErrorMessageAndSetsIsValidToFalse()
        {
            // Arrange
            var output = new Output();
            var errorMessage = "An error occurred";

            // Act
            output.AddErrorMessage(errorMessage);

            // Assert
            Assert.Contains(errorMessage, output.ErrorMessages);
            Assert.False(output.IsValid);
        }

        [Fact]
        public void AddMessage_AddsMessageToMessagesList()
        {
            // Arrange
            var output = new Output();
            var message = "A message";

            // Act
            output.AddMessage(message);

            // Assert
            Assert.Contains(message, output.Messages);
        }
    }
}
