// See https://aka.ms/new-console-template for more information
using DroidRallyAssignment.Application;

Console.WriteLine("Hello, World!");

/**Brief:
 * Droid A has a position (X, Y) and a direction (N, S, E, W)
 * Grid start coordinates are (0,0) in the bottom left corner
 * Droid commands: turn left 90 degress (L), turn right 90 degrees (R), move forward 1 position in current direction (M)
 * 
 * Given the dimensions of the grid, the initial droid position and direction (heading) and a set of commands to execute, 
 * initialise each droids positoin and direction on the grid and then execute each droids command sequence one at a time,
 * displaying the droid's current poisition and direction after each execution, as well as the final position and direction after all commands have been executed.
 * 
 **/

Console.WriteLine("Welcome to the droid navigation module");
Console.WriteLine("Input the grid's upper-right coordinates and press Enter to begin.");
Console.WriteLine("Format: X Y (Two positive integers seperated by a single space");

var gridDimensions = Console.ReadLine();

if (!DroidInputValidator.IsValidGridDimensions(gridDimensions))
{
    Console.WriteLine("Invalid grid dimensions. Please ensure you enter two positive integers separated by a space.");
    return;
}
