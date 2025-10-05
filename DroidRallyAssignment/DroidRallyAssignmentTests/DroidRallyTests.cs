using DroidRallyAssignment.Application;
using DroidRallyAssignment.Domain.Enums;

namespace DroidRallyAssignmentTests
{
    public class DroidRallyTests
    {
        [Fact]
        public void Given_GridDimensions_When_DimensionsAreValid_Then_ShouldAssertAsValid()
        {
            // Arrange
            var gridDimensions = "5 5";
            // Act
            var result = DroidRallyAssignment.Application.DroidInputValidator.IsValidGridDimensions(gridDimensions);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Given_GridDimensions_When_DimensionsAreInValid_Then_ShouldFailAssertAsValid()
        {
            // Arrange
            var gridDimensions = "55";
            // Act
            var result = DroidRallyAssignment.Application.DroidInputValidator.IsValidGridDimensions(gridDimensions);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Given_DroidInput_When_DroidInputValid_Then_ShouldAssertAsValid()
        {
            var droidInput = "1 2 N";
            
            var result = DroidRallyAssignment.Application.DroidInputValidator.IsValidDroidInput(droidInput);
            
            Assert.True(result);
        }

        [Fact]
        public void Given_DroidInput_When_DroidInputInValid_Then_ShouldFailAssertAsValid()
        {
            var droidInput = "12NFF";
            
            var result = DroidRallyAssignment.Application.DroidInputValidator.IsValidDroidInput(droidInput);
            
            Assert.False(result);
        }

        [Theory]
        [InlineData("N", Directions.N)]
        [InlineData("E", Directions.E)]
        [InlineData("S", Directions.S)]
        [InlineData("W", Directions.W)]
        public void Given_Direction_When_DirectionIsValid_Then_ShouldParseCorrectly(string inputDirection, Directions expectedDirection)
        {
            Assert.True(EnumMapper.TryParseDirection(inputDirection, out var resultDirection));
            Assert.Equal(expectedDirection, resultDirection);
        }

        [Theory]
        [InlineData("NE")]
        [InlineData("X")]
        [InlineData("north")]
        [InlineData("-1")]
        [InlineData("")]
        public void Given_Direction_When_DirectionIsInValid_Then_ShouldFailParse(string inputDirection)
        {
            Assert.False(EnumMapper.TryParseDirection(inputDirection, out var resultDirection));
        }
    }
}