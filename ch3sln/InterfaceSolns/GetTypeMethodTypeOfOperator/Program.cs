using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("gday types app");

        int a = 42;
        object b = a; ;

        WriteLine($"a.GetType(): {a.GetType()}");
        WriteLine($"typeof(int): {typeof(int)}");
        WriteLine($"b.GetType(): {b.GetType()}");
        WriteLine($"typeof(object): {typeof(object)}");

        // a.GetType(): System.Int32
        // typeof(int): System.Int32
        // b.GetType(): System.Int32
        // typeof(object): System.Object
    }
}
