
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T4_ProblemsWithForeground!\n");
        var t = new Thread(Worker);
        t.IsBackground = true;
        t.Start();
        t.Join();
        void Worker()
        {
            try
            {
                Thread.Sleep(500);
                WriteLine("Worker is working...[background: {0}]", Thread.CurrentThread.IsBackground);
            }
            finally
            {
                Thread.Sleep(500);
                WriteLine("Worker is finishing...[background: {0}]", Thread.CurrentThread.IsBackground);
                Thread.Sleep(500);
            }
        }
    }
}

// Problem 1 with [fg_threads]:
// - termination before cleanup/finally completed
// Solution:
// - wait() for thread to complete
