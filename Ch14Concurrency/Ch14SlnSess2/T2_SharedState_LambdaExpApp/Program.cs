using static System.Console;

internal class Program
{
    delegate void tonys_void_dg();
    static void Main(string[] args)
    {
        WriteLine("Hello, T2_SharedState_LambdaExpApp!");
        bool done = false;
        tonys_void_dg action = () =>
        {
            if (!done) { done = true; Console.WriteLine("Done"); }
        };

        tonys_void_dg dg = action;


        var action2 = () =>
        {
            if (!done) { done = true; Console.WriteLine("Done"); }
        };

        tonys_void_dg dg2 = action2.Invoke;
    }
}
