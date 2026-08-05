using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T4_Local_vs_Shared_State!");

        new Thread(Go).Start();
        Go();
    }

    static void Go() 
    {
        for (int cycles = 0; cycles < 5; cycles++)
        {
            Write("?");
        }
    }
}

