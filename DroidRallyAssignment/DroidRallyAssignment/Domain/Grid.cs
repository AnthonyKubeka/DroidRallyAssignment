using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroidRallyAssignment.Domain
{
    public class Grid
    {
        public int TopRightX { get; set; }
        public int TopRightY { get; set; }
        public static Grid InitialiseGrid(string gridDimensions)
        {
            var dimensions = gridDimensions.Split(' ');
            return new Grid
            {
                TopRightX = int.Parse(dimensions[0]),
                TopRightY = int.Parse(dimensions[1])
            };
        }
    }
}
