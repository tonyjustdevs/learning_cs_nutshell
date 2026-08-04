using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, UtilityClassesApp!");
        Console.WindowWidth = Console.LargestWindowWidth;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("test... 50%");
        Console.CursorLeft -= 3;
        Console.Write("90%");     // test... 90%
    }
}
