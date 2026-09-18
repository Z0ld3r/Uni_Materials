using Goldsmith.TestUtils;

namespace Goldsmith;

class Program
{
    static void Main(string[] args)
    {
        PrettyPrint.EnableGreen = Console.IsOutputRedirected;
        PrettyPrint.EnableGreen = true; // ha nagyon útban van a sok szöveg, kommenteljük ki
        Console.Title = "Goldsmith 3";
        PrettyPrint.Normal("Testing Goldsmith 3");

        TestRunner runner = new TestRunner();
        runner.Run();
        Environment.ExitCode = runner.TestCount - runner.TestsSucceeded;
        Console.WriteLine();
        PrettyPrint.Normal("Tests have finished.");
        if (runner.TestsSucceeded == runner.TestCount)
        {
            PrettyPrint.Green($"All {runner.TestCount} tests succeeded.", true);
        }
        else
        {
            PrettyPrint.Red($"{runner.TestsSucceeded} of {runner.TestCount} have been successful.");
        }

    }
}