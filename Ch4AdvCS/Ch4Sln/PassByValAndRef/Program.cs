using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        int a = 1;
        int b;
        b = a;
        WriteLine($"a: {a}, b: {b}");
        b++;
        WriteLine($"a: {a}, b: {b}");

    }

    static void Meth1(int x)
    {
        x++;
    }
}
