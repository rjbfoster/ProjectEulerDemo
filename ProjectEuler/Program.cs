using ProjectEuler.Problems;

bool isRunning = true;

while (isRunning)
{
    DisplayWelcome();
}

void DisplayWelcome()
{
    // Main menu
    //  Display a list of options to the user and prompt for input.
    Console.WriteLine("\nProject Euler Problem Solver\n\n" +
                    "Options:\n\n" +
                    $"\t[1 - {Problem.AllProblems.Count}]\t Enter a problem number you wish to solve\n" +
                    "\t[i]\t Display index of available problems\n" +
                    "\t[x]\t Exit program\n");
    Console.Write("Select option: ");

    string input = Console.ReadLine() ?? "";
    Console.WriteLine();

    if (int.TryParse(input, out var value))
    {
        // The input is an integer. Attempt to match it, and if not possible, throw error.
        try
        {
            DisplayProblem(Math.Abs(value));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    else
    {
        // The input is not an integer. Attempt to match it to other available options.
        //  Return user to menu if input does not match available options.
        switch (input.ToLower())
        {
            case "i":
                DisplayIndex();
                break;

            case "x":
                isRunning = false;
                break;

            default:
                Console.WriteLine("Your input did not match any available problems or other input options. Please check your input and try again.");
                break;
        }
    }
}

void DisplayProblem(int intProblem)
{
    if (intProblem < 0 || intProblem > 3)
    {
        throw new ProblemNotFoundException("The number you entered did not match any of the available problems. Please check the problem index and try again.");
    }
    else
    {
        Problem.GetProblem(intProblem);
        Console.WriteLine("Press any key to return to main menu.");
        Console.ReadKey();
    }
}

void DisplayIndex()
{
    Console.WriteLine("Displaying index:");
    Problem.ShowProblems();
    Console.WriteLine("Press any key to return to main menu.");
    Console.ReadKey();
}