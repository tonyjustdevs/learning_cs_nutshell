using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("[mn_1] program started...");
        
        var download_task = DownloadChunkedData(); 
        // hot task
        
        WriteLine("[mn_2] program ending...");

        ReadLine();
    }

    public async static Task DownloadChunkedData()
    {
        for (int i = 0; i < 100; i++)
        {
            var delayed_task = Task.Delay(500);
            // - [1] awaitable task returned immediately
            await delayed_task; 
            // - [2] await      ---> thread released back to threadpool
            // - [3] resumes    ---> after 500 ms
            WriteLine($"chunk_{i} downloaded...");
        }
    }
}

// [1] [meth] add some async download task
// [2] [meth] add cancellation token

// [3] [main] add cancellation_token instance
// [4] [main] add cancellation_token to method_call

// [5] [main] add try-catch
// [6] [main] call cancel
// [7] [main] catch cancellation
