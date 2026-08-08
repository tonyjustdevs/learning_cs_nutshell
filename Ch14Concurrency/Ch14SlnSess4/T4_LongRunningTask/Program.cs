using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T4_LongRunningTask!");
        var t = new TaskFactory().StartNew(() =>
        {
            WriteLine($"long task started...[tpool: {Thread.CurrentThread.IsThreadPoolThread}]");
            Thread.Sleep(2000);
            WriteLine($"long task ending...[tpool: {Thread.CurrentThread.IsThreadPoolThread}]");
        },
        TaskCreationOptions.LongRunning);
        ReadLine();
        //t.Start();
    }
}

