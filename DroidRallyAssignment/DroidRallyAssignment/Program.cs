// See https://aka.ms/new-console-template for more information
using DroidRallyAssignment.Application;
using DroidRallyAssignment.Domain;
using DroidRallyAssignment.Domain.Enums;

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

var grid = Grid.InitialiseGrid(gridDimensions);
Console.WriteLine($"Grid initialised with upper-right coordinates: {grid.TopRightX} {grid.TopRightY}");

int droidInputEmptyLineCount = 0;
while (true)
{
    Console.WriteLine("Input the droid's starting position and direction, then press Enter.");
    Console.WriteLine("Format: X Y D. Two non-negative integers and a direction (N, E, S, W) seperated by a single space");
    Console.WriteLine("Press Enter on an empty line twice here to finish all input and exit.");
    Console.WriteLine("Awaiting droid starting position and direction...");

    var droidInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(droidInput))
    {
        droidInputEmptyLineCount++;
        if (droidInputEmptyLineCount >= 2)
        {
            Console.WriteLine("Finished all input. End state below:");
            Console.WriteLine(grid.GetDroidStates());
            Console.WriteLine("Exiting droid navigation module. Goodbye!");
            break;
        }
        Console.WriteLine("Empty line detected. Press Enter again to exit or provide droid starting position and direction to continue.");
        continue;

    }

    droidInputEmptyLineCount = 0;

    if (!DroidInputValidator.IsValidDroidInput(droidInput))
    {
        Console.WriteLine("Invalid droid input. Please ensure you enter two non-negative integers and a direction (N, E, S, W) separated by spaces. Try again");
        continue;
    }

    var droid = Droid.InitialiseDroid(droidInput);
    grid.AddDroid(droid);

    Console.WriteLine($"Droid initialised at position and direction: {droidInput}");

    //--Command entry for droid--//

    Console.WriteLine("Input a command for the droid, then press Enter.");
    Console.WriteLine("Format: L (for left) R (for right) M (for move in current direction).");
    Console.WriteLine("You can enter a single command or a sequence like LMLMR.");
    Console.WriteLine("Press Enter on an empty line twice to finish entering commands for this droid and return to doing so for another droid.");

    int commandInputEmptyLineCount = 0;

    while (true) //while true is weird, but works for keeping console app 'alive' until termination condition
    {
        Console.WriteLine("Awaiting command input...");
        var commandInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(commandInput))
        {
            commandInputEmptyLineCount++;
            if (commandInputEmptyLineCount >= 2)
            {
                Console.WriteLine("Finished entering commands for this droid. Returning to droid input.");
                break;
            }
            Console.WriteLine("Empty line detected. Press Enter again to finish commands for this droid or provide command input to continue.");
            continue;
        }

        commandInputEmptyLineCount = 0;

        if (!EnumMapper.TryParseCommandSequence(commandInput, out var commands))
        {
            Console.WriteLine("Invalid command input. Please ensure you enter a string of commands containing only the characters L, R, and M. Or Press Enter twice to end input for this droid");
            continue;
        }

        foreach (var command in commands)
        {
            var currentPosition = droid.GetState();
            droid.ExecuteCommand(command, grid);

            if (currentPosition == droid.GetState() && command == Commands.M)
            {
                Console.WriteLine($"Droid attempted to execute command: {command}, but move was invalid (out of bounds or position occupied). Current position and direction remains: {droid.GetState()}");
                continue;
            }

            Console.WriteLine($"Droid executed command: {command}. Current position and direction: {droid.GetState()}");
        }
    }
}