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
        public List<Droid> Droids { get; set; } = new List<Droid>();
        public static Grid InitialiseGrid(string gridDimensions)
        {
            var dimensions = gridDimensions.Split(' ');
            return new Grid
            {
                TopRightX = int.Parse(dimensions[0]),
                TopRightY = int.Parse(dimensions[1])
            };
        }
        public void AddDroid(Droid droid)
        {
            Droids.Add(droid);
        }
        public string GetDroidStates()
        {
            var states = Droids.Select(d => d.GetState());
            return string.Join(Environment.NewLine, states);
        }
    }
}
