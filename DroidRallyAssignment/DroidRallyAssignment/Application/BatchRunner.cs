using DroidRallyAssignment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroidRallyAssignment.Application
{
    public static class BatchRunner
    {
        public static IEnumerable<string> Process(IEnumerable<string> input)
        {
            using var iterator = input.GetEnumerator();

            if (!iterator.MoveNext())
            {
                yield break;
            }

            var gridDimensions = iterator.Current;

            if (!DroidInputValidator.IsValidGridDimensions(gridDimensions))
            {
                throw new FormatException("Invalid grid dimensions. Please ensure you enter two positive integers separated by a space.");
            }

            var grid = Grid.InitialiseGrid(gridDimensions);

            while (true)
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                var droidInput = iterator.Current;
                if (string.IsNullOrWhiteSpace(droidInput))
                {
                    break;
                }
                if (!DroidInputValidator.IsValidDroidInput(droidInput))
                {
                    throw new FormatException("Invalid droid input. Please ensure you enter two non-negative integers and a direction (N, E, S, W) separated by a single space.");
                }
                var droid = Droid.InitialiseDroid(droidInput);
                grid.AddDroid(droid);
                if (!iterator.MoveNext())
                {
                    throw new FormatException("Expected commands input after droid input.");
                }
                var commandsInput = iterator.Current;

                if (!EnumMapper.TryParseCommandSequence(commandsInput, out var commands))
                {
                    throw new FormatException("Invalid command sequence. Please ensure you enter a sequence of commands (L, R, M) with no spaces.");
                }

                foreach (var command in commands)
                {
                    droid.ExecuteCommand(command, grid);
                }

                yield return droid.GetState();
            }

        }
    }
}
