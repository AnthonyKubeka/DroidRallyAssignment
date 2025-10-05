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
        public string GetState()
        {
            return $"{X} {Y} {Direction}";
        }

        public void ExecuteCommand(Commands command, Grid grid)
        {
            switch (command)
            {
                case Commands.L:
                    TurnLeft();
                    break;
                case Commands.R:
                    TurnRight();
                    break;
                case Commands.M:
                    MoveForward(grid);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), command, null);
            }
        }
        private void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;
                case Directions.W:
                    Direction = Directions.S;
                    break;
                case Directions.S:
                    Direction = Directions.E;
                    break;
                case Directions.E:
                    Direction = Directions.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(); 

            }
        }

        private void TurnRight()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;
                case Directions.W:
                    Direction = Directions.N;
                    break;
                case Directions.S:
                    Direction = Directions.W;
                    break;
                case Directions.E:
                    Direction = Directions.S;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        private void MoveForward(Grid grid)
        {
            var newX = X;
            var newY = Y;

            switch (Direction)
            {
                case Directions.N:
                    newY++;
                    break;
                case Directions.E:
                    newX++;
                    break;
                case Directions.S:
                    newY--;
                    break;
                case Directions.W:
                    newX--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (IsAbleToMoveForward(newX, newY, grid))
            {
                X = newX;
                Y = newY;
            }
        }

        private bool IsAbleToMoveForward(int newX, int newY, Grid grid)
        {
            if (newX < 0 || newY < 0 || newX > grid.TopRightX || newY > grid.TopRightY)
            {
                return false;
            }
            return true;
        }
    }
}
