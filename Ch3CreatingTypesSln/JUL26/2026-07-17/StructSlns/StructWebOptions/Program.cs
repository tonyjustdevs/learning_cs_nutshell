using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello WebOptions Struct");
    }
}


public struct WebOptions
{
    string protocol;
    string Protocol { 
        get => protocol ?? "https";
        set => protocol = value; } 
}