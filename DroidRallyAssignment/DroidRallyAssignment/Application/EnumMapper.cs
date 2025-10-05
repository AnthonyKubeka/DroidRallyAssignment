using DroidRallyAssignment.Domain.Enums;

namespace DroidRallyAssignment.Application
{
    public static class EnumMapper
    {
        public static bool TryParseDirection(this string directionStringInput, out Directions direction)
        {
            direction = default;
            if (string.IsNullOrWhiteSpace(directionStringInput))
            {
                return false;
            }

            switch (directionStringInput.Trim().ToUpperInvariant())
            {
                case "N":
                    direction = Directions.N;
                    return true;
                case "E":
                    direction = Directions.E;
                    return true;
                case "S":
                    direction = Directions.S;
                    return true;
                case "W":
                    direction = Directions.W;
                    return true;
                default:
                    return false;
            }
        }
        public static bool TryParseCommandSequence(this string commandSequenceInput, out List<Commands> commands)
        {
            commands = new List<Commands>();
            if (string.IsNullOrWhiteSpace(commandSequenceInput))
            {
                return false;
            }
            foreach (var character in commandSequenceInput.Trim().ToUpperInvariant())
            {
                if (!TryParseCommand(character, out var command))
                {
                    return false;
                }
                commands.Add(command);
            }
            return true;
        }

        private static bool TryParseCommand(this char commandCharInput, out Commands command)
        {
            command = default;
            switch (char.ToUpperInvariant(commandCharInput))
            {
                case 'L':
                    command = Commands.L;
                    return true;
                case 'R':
                    command = Commands.R;
                    return true;
                case 'M':
                    command = Commands.M;
                    return true;
                default:
                    return false;
            }
        }
    }
}
