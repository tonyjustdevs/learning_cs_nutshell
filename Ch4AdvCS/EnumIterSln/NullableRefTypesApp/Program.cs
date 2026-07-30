using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        var c = new Customer();
        WriteLine(c.Name.Length);
    }

}

class Customer
{
    public string Name;
}