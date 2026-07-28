using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Nullables2!");

        object o = "mate";
        int? x = o as int?;
        WriteLine($"x.HasValue: {x.HasValue} (exp: false)");
        
        // 1. box a string
        // 2. convert 'as' to int
        // 3. show hasValue is false
    }
}
