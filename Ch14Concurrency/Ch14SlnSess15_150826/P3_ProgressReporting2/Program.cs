using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, P3_ProgressReporting2World!");
        
        Action<int> progress_lambda = i => WriteLine($"{i}%");
        
        await DoAsyncWork(progress_lambda);
    }

    static Task DoAsyncWork(Action<int> onProgressPercentChange)
    {
        return Task.Run(() =>
        {
            for (int i = 0; i <= 10; i++)
            {
                WriteLine($"doing important job_{i}...");
                Thread.Sleep(1000);
                onProgressPercentChange(i * 10);
            }
        });

    }
}
 

// [1] create async method
// [2] creates a new task to do work
// [3] each iteration calls progress_reporting delegate