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
    }
}