using DroidRallyAssignment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool TryParseCommand(this string commandInput, out Commands command)
        {
            command = default;
            switch (commandInput.ToUpperInvariant())
            {
                case "L":
                    command = Commands.L;
                    return true;
                case "R":
                    command = Commands.R;
                    return true;
                case "M":
                    command = Commands.M;
                    return true;
                default:
                    return false;
            }
        }
    }
}
