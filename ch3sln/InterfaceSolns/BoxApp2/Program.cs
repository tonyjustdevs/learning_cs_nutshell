using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("boxing app 2!");
        int a = 42;
        object b = a;
        a = 69;

        string? b_str = b.ToString();
        WriteLine($"b_str:{b_str}");
        //WriteLine($"a:{a}");
        //WriteLine($"b:{b}");
    }
}
