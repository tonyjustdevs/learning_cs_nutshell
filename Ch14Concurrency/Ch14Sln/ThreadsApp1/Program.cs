using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, ThreadsApp1!");
        WriteLine($"{Thread.CurrentThread.Name}: {Thread.CurrentThread.IsAlive} (main)");

        Thread t = new Thread(WriteY);
        t.Start();
        WriteLine($"{t.Name}: {t.IsAlive} (y in main)");
        for (int i = 0; i < 1000; i++)
        {
            Write("x");
        }
        WriteLine($"{t.Name}: {t.IsAlive} (y in main)");
        WriteLine($"{Thread.CurrentThread.Name}: {Thread.CurrentThread.IsAlive} (main)");

    }
    static void WriteY()
    {
        WriteLine($"{Thread.CurrentThread.Name}: {Thread.CurrentThread.IsAlive} (y in y)");
        for (int i = 0; i < 1000; i++)
        {
            Write("y");
        }
        WriteLine($"{Thread.CurrentThread.Name}: {Thread.CurrentThread.IsAlive} (y in y)");
    }
}
