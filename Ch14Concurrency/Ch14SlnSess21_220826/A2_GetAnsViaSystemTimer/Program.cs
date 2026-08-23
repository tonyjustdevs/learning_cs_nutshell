using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("[mn_1] A2_GetAnsViaSystemTimer!");

        // [1] add a cts
        TaskCompletionSource<int> cts = new();

        // [2a] add delay via Task (threadpool)
        //Task.Delay(3000).ContinueWith(_ => cts.SetResult(69));
        // - this returns a task instantly and main_thread continues
        // - if no await, main thread ends

        // [2b] add delay via manual Thread (threadpool)
        var t = new Thread(() =>
        {
            WriteLine($"[td_1]doing i/o job [{Thread.get}]");
            Thread.Sleep(2000);         // [2a] simulate i/o job
            cts.SetResult(42);          // [2b] receive i/o result
        });
        t.Start();                      // [2c] start manual thread
        
        // [3] set task result
        var life_task = cts.Task;

        // [4] get task result
        WriteLine($"life_task.Result: {life_task.Result} (this waits til completion)");

        WriteLine("program end");

    }
}
