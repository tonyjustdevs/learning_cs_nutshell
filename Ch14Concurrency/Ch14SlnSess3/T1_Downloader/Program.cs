using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T1_LmbExp_Cv!");

        for (int i = 0; i < 10; i++)
        {
            int temp = i;
            new Thread(() => Write(temp)).Start();
        }
    }
}


