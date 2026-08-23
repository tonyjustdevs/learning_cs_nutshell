using System.Timers;
using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, A1_TaskCompletionSrc!");

        var task = AsyncRun(GetIOIntValue);

        WriteLine($"GetIOIntValue: {await task}");

    }
    static int GetIOIntValue()
    {
        WriteLine("getting io value...");
        Thread.Sleep(2000);
        WriteLine("io value is ready!");
        return 42;
    }
    static Task<int> AsyncRun(Func<int> io_int_function)
    {
        TaskCompletionSource<int> tcs = new();

        System.Timers.Timer timer = new(4000) { AutoReset = false };

        timer.Elapsed += (_, _) =>
        {
            WriteLine("timer ended");
            var io_int_result = io_int_function();
            tcs.SetResult(io_int_result);
            timer.Dispose();
        };

        timer.Start();
        WriteLine("timer started...");

        return tcs.Task;
    }
}
