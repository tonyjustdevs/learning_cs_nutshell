using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, A5_TCSAsyncTask!");

        // Goal: Task (doesn't use thread) that fires event (via OS) after n-seconds
        //var life_task = GetLifeLater();
        //WriteLine($"life: {life_task}");
        var awaiter = GetLifeLater().GetAwaiter();
        awaiter.OnCompleted(() => 
        {
            WriteLine("awaiter:", awaiter);
            WriteLine("awaiter.IsCompleted:", awaiter.IsCompleted);
            WriteLine("awaiter.GetResult():", awaiter.GetResult());
        });
        WriteLine("ended");
    }

    static Task<int> GetLifeLater()
    {
        TaskCompletionSource<int> tcs = new();
        
        System.Timers.Timer timer = new(3000) { AutoReset = false };

        timer.Elapsed += delegate
        {
            tcs.SetResult(69);
            timer.Dispose();
        };

        timer.Start();

        return tcs.Task;
    }
}
