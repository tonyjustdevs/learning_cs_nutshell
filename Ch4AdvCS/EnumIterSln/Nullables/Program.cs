using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, Nullables!!");

        int? x = 69;

        WriteLine($"x.HasValue: {x.HasValue} (exp: true)");
        WriteLine($"x.Value: {x.Value} (exp: 69)");

        int? y=null;
        WriteLine($"y.HasValue: {y.HasValue} (exp: false)");
        WriteLine($"y.Value: {y.GetValueOrDefault()} (exp: 0)");

        string? a= null;
        WriteLine($"a: {a} (exp: null)");


    }
}
