using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello ThrowingExceptionsApp!");
        try
        {
            Display(null);
        }
        catch (Exception e)
        {
            WriteLine($"tp_handled: '{e.Message}'");
        }
    }
    static void Display(string name)
    {
        //if (name is null)
        //    throw new ArgumentNullException(nameof(name));
        ArgumentNullException.ThrowIfNull(name);
        WriteLine($"name: {name}");
    }
}

