using DroidRallyAssignment.Application;
using DroidRallyAssignment.Domain;
using DroidRallyAssignment.Domain.Enums;

namespace DroidRallyAssignmentTests
{
    public class DroidRallyTests
    {
        [Theory]
        [InlineData("5 5")]
        [InlineData("10 3")]
        public void Given_GridDimensions_When_DimensionsAreValid_Then_ShouldAssertAsValid(string gridDimensions)
        {
            Assert.True(DroidInputValidator.IsValidGridDimensions(gridDimensions));
        }

        [Theory]
        [InlineData("")]
        [InlineData("5")]
        [InlineData("55")]
        [InlineData("5,5")]
        [InlineData("0 5")]
        [InlineData("-1 2")]
        [InlineData("5 0")]
        public void Given_GridDimensions_When_DimensionsAreInValid_Then_ShouldFailAssertAsValid(string gridDimensions)
        {
            Assert.False(DroidInputValidator.IsValidGridDimensions(gridDimensions));
        }

        [Fact]
        public void Given_DroidInput_When_DroidInputValid_Then_ShouldAssertAsValid()
        {
            var droidInput = "1 2 N";

            var result = DroidInputValidator.IsValidDroidInput(droidInput);

            Assert.True(result);
        }

        [Fact]
        public void Given_DroidInput_When_DroidInputInValid_Then_ShouldFailAssertAsValid()
        {
            var droidInput = "12NFF";

            var result = DroidInputValidator.IsValidDroidInput(droidInput);

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

        [Fact]
        public void Given_CommandSequence_When_CommandSequenceIsValid_Then_ShouldParseCorrectlySpecificCommand()
        {
            var input = "L";

            var result = EnumMapper.TryParseCommandSequence(input, out var command);

            Assert.True(result);
            Assert.Equal(Commands.L, command.First());
        }

        [Theory]
        [InlineData("L")]
        [InlineData("LMLMR")]
        [InlineData("mmm")]
        [InlineData("rrl")]
        public void Given_CommandSequence_When_CommandSequenceIsValid_Then_ShouldParseCorrectly(string input)
        {
            var result = EnumMapper.TryParseCommandSequence(input, out var command);

            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("LMX")]
        [InlineData("M1")]
        public void Given_CommandSequence_When_CommandSequenceIsInvalid_Then_ShouldFailParse(string input)
        {
            var result = EnumMapper.TryParseCommandSequence(input, out var command);

            Assert.False(result);
        }

        [Fact]
        public void Given_Droid_When_CommandIsTurn_Then_ShouldFaceCorrectDirection()
        {
            var g = Grid.InitialiseGrid("5 5");
            var d = Droid.InitialiseDroid("1 1 N");

            d.ExecuteCommand(Commands.L, g);
            Assert.Equal(Directions.W, d.Direction);

            d.ExecuteCommand(Commands.L, g);
            Assert.Equal(Directions.S, d.Direction);

            d.ExecuteCommand(Commands.L, g);
            Assert.Equal(Directions.E, d.Direction);

            d.ExecuteCommand(Commands.L, g);
            Assert.Equal(Directions.N, d.Direction);

            d.ExecuteCommand(Commands.R, g);
            Assert.Equal(Directions.E, d.Direction);
        }

        [Fact]
        public void Given_Droid_When_CommandIsMove_Then_ShouldMoveInCorrectDirectionIfMoveWithinBoundsOfGrid()
        {
            var g = Grid.InitialiseGrid("5 5");
            var d = Droid.InitialiseDroid("1 1 N");

            d.ExecuteCommand(Commands.M, g);
            Assert.Equal("1 2 N", d.GetState());
        }

        [Fact]
        public void Given_Droid_When_CommandIsMove_Then_ShouldNotMoveIfWouldMoveOutOfBoundsOfGrid()
        {
            var g = Grid.InitialiseGrid("5 5");
            var d = Droid.InitialiseDroid("5 5 N");

            d.ExecuteCommand(Commands.M, g);
            Assert.Equal("5 5 N", d.GetState());
        }
    }
}