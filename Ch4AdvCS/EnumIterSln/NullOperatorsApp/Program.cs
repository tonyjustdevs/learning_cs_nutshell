using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Null Operators");

        //int? x = null;
        //int y = x ?? 5;

        //int timeout = Settings.Timeout;
        //WriteLine(timeout);
        int? a = null, b = null, c = 2;
        Console.WriteLine(a ?? b ?? c);

        System.Text.StringBuilder? sb = null;
        int? length = sb?.ToString().Length ?? 42;
        WriteLine(length);
    }

}

class Settings
{
    public static int Timeout { get; set; }
}
