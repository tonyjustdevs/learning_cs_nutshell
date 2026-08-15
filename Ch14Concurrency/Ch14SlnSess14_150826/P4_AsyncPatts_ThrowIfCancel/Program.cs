using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("[mn_1] hello P4_AsyncPatts_ThrowIfCancel!");

        CancellationTokenSource cts = new();

        var delayed_task = Task.Delay(5000).ContinueWith(task => // [resumes] in 5000ms
        {   
            WriteLine($"{task.Id} has completed..."); 
            cts.Cancel();
        });
        
        WriteLine($"{delayed_task.Id} started...");

        try
        {
            SynchronousMethod(cts.Token);

        }
        catch (Exception e)
        {
            WriteLine($"error_caught: {e.Message} [{e.GetType()}]");
        }
        WriteLine("[mn_2] bye");
    }

    static void SynchronousMethod(CancellationToken ct)
    {
        while (true)
        {
            Thread.Sleep(500);
            ct.ThrowIfCancellationRequested();
            WriteLine("did some work...");
        }
    }


    // [1] create a async task 
    // [2] has a Task.Delay
    // [3] ContinueWith with cts.Cancel()
    // [4] sync Task(token)
    // [5] then cancels


}
