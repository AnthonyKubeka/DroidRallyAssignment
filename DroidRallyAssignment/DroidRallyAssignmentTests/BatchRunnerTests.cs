using DroidRallyAssignment.Application;

namespace DroidRallyAssignmentTests
{
    public class BatchRunnerTests
    {
        [Fact]
        public void Given_BatchInput_When_InputIsInCorrectFormat_Then_ShouldProcessBatchInput()
        {
            var batchInput = new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var expectedOutput = new List<string>
            {
                "1 3 N",
                "5 1 E"
            };

            var result = BatchRunner.Process(batchInput).ToList();
            
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Given_BatchInput_When_GridInvalid_ThenThrowFormatException()
        {
            var input = new[] { "5", "1 2 N", "M" };
            Assert.Throws<FormatException>(() => BatchRunner.Process(input).ToList());
        }

        [Fact]
        public void Given_BatchInput_When_MissingCommands_Then_ThrowFormatException()
        {
            var input = new[] { "5 5", "1 2 N" };
            Assert.Throws<FormatException>(() => BatchRunner.Process(input).ToList());
        }
    }
}