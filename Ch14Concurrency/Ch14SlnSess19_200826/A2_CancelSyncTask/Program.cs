using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("[mn_1] hello A2_CancelSyncTask!");
        var long_sync_task = LongSyncJob();

        WriteLine("[mn_2] waiting for long job...!");

        CancellationTokenSource cts = new();
        Task.Delay(5000).ContinueWith(_ => cts.Cancel());

        try
        {
            long_sync_task.Wait(cts.Token);

        }
        catch (Exception ex)
        {
            WriteLine($"\nCaught-Error: {ex.Message} [{ex.GetType()}]");
        }
        
        
        WriteLine("\n[mn_2] good-bye!");
    }

    static async Task LongSyncJob()
    {
        WriteLine($"LongSyncJob starts...(giving to threadpool...) [{Thread.CurrentThread.ManagedThreadId}]");

        var task = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                WriteLine($"- iteration_{i} [{Thread.CurrentThread.ManagedThreadId}]");
                Thread.Sleep(1000);
            }
            WriteLine($"LongSyncJob completed... [{Thread.CurrentThread.ManagedThreadId}]");
        });
        await task;
    }
    // add some sync task (replicate old-api, no async capability)
}
