using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("[mn_1] main started");
        CancellationTokenSource cts = new();
        var foo_task = Foo(cts.Token); 
        
        WriteLine("[mn_2] we now wait for all tasks to complete...");
        // dont await Foo() because we want main_thread to continue
        var customer_task = Task.Delay(5000);
        await customer_task;
        cts.Cancel();
        await foo_task;
        //foo_task.Wait(,)

        WriteLine("[mn_3] program ended");
        async Task Foo(CancellationToken ctoken)
        {
            for (int i = 0; i < 10; i++)
            {
                var task = Task.Delay(1000,ctoken);
                await task; // await each loop to completes
                WriteLine($"{i}_completed");
            }
        }
    }

    // [2] add cancel via user

}
