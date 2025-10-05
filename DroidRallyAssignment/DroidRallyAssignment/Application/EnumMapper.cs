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

            switch (directionStringInput.Trim().ToUpper())
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
    }
}
