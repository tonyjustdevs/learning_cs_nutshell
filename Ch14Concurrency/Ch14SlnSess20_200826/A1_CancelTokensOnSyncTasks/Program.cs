using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("[mn_1] A1_CancelTokensOnSyncTasks!");
        //LongAssJobSync();

        // - this task represents the [longassjob]
        // - it will complete on the threadpool
        // - task.Status changes from running to complete?

        CancellationTokenSource cts = new();
        
        try
        {

            var task = LongAssJobSync2(); // long ass job
            WriteLine("[mn_2] task.Status :{0}", task.Status);

            Task.Run(async () => // all these errors are not real
            {                    // they want to await the task but we dont need to 
                await Task.Delay(2000);
                // this is a hot task
                // it runs straight away
                // in 2 seconds it continues
                cts.Cancel();
            });
            WriteLine("[mn_3] task.Status :{0}", task.Status);
            task.Wait(cts.Token);
            WriteLine("[mn_4] task.Status :{0}", task.Status);
        }
        catch (Exception ex)
        {
            WriteLine($"ex.Message: {ex.Message}");
        }
        //WriteLine("[mn_3] task.Status :{0}", task.Status);
        // - main thread waits for long-ass-job to complete


        // [Q] how do we add a cancellation token???
        // - Run a timer: [Task.Delay()] in the [main_thread]
        // - send a ctoken after task is complete??
    }

    // [1] whats the difference throwing [method_body] to threadpool
    // [2] vs throwing the [method] call to threadpool?

    static Task LongAssJobSync2()
    {
        var task = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Write($"\npartition_{i} processing [{Thread.CurrentThread.ManagedThreadId}]...");
                Thread.Sleep(200);
                Write($"[completed][{Thread.CurrentThread.ManagedThreadId}]");
                Thread.Sleep(100);
            }
        });
        return task;

        // [2] add a cancellation token
        //await task;
    }

    static void LongAssJobSync()
    {
        for (int i = 0; i < 10; i++)
        {
            Write($"\npartition_{i} processing...");
            Thread.Sleep(1000);
            Write($"[completed]\n");
            Thread.Sleep(500);
        }
    }

}
