using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroidRallyAssignment.Application
{
    public static class DroidInputValidator
    {
        public static bool IsValidGridDimensions(string gridDimensions)
        {
            if (string.IsNullOrWhiteSpace(gridDimensions))
            {
                return false;
            }

            var dimensions = gridDimensions.Split(' ');
            if (dimensions.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(dimensions[0], out int x) || !int.TryParse(dimensions[1], out int y))
            {
                return false;
            }

            if (x <= 0 || y <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
