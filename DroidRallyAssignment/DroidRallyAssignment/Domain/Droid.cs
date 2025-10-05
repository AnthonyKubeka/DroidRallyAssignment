using DroidRallyAssignment.Application;
using DroidRallyAssignment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroidRallyAssignment.Domain
{
    public class Droid
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
        public static Droid InitialiseDroid(string droidInput)
        {
            var inputs = droidInput.Split(' ');
            var x = int.Parse(inputs[0]);
            var y = int.Parse(inputs[1]);
            EnumMapper.TryParseDirection(inputs[2], out var direction);

            return new Droid
            {
                X = x,
                Y = y,
                Direction = direction
            };
        }
    }
}
