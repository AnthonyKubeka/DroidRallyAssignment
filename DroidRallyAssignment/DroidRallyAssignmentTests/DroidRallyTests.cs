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
    }
}