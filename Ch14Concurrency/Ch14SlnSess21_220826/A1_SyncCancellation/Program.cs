using System.Xml.Serialization;
using static System.Console;
partial class Program
{
    static void Main(string[] args)
    {
        WriteLine($"G'day A1_SyncCancellation![{Thread.CurrentThread.ManagedThreadId}]");

        CancellationTokenSource cts = new();

        //var task1 = LongCPUJob1(cts.Token);
        WriteLine("[mn_1]");
        var task1 = LongCPUJob1(cts.Token);
        var task2 = RunJob2();

        Task.Delay(3000).ContinueWith(ant =>
        {
            cts.Cancel();  // after 3000ms, cancel a task? 
        });
        WriteLine("[mn_2]");

        Task[] tasks_arr = [task1, task2];
        
        int winner_id = Task.WaitAny(tasks_arr);
        WriteLine($"winner_id: {winner_id}");
        WriteLine($"tasks_arr[winner_id].Id: {tasks_arr[winner_id].Id}");
        WriteLine("[mn_3]");
        WriteLine($"bye!![{Thread.CurrentThread.ManagedThreadId}]");
    }

    static Task LongCPUJob1(CancellationToken ctoken)
    {
        var task = Task.Run(() => 
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                ctoken.ThrowIfCancellationRequested();
                WriteLine($"[LJ1] pt{i}_done. [{Thread.CurrentThread.ManagedThreadId}]");
            }
            WriteLine($"[LJ1] job_done.[{Thread.CurrentThread.ManagedThreadId}]");
        });

        return task;
        
    }
    static Task RunJob2()
    {
        var task = Task.Run(() => LongCPUJob2());
        return task;
    }
    static void LongCPUJob2()
    {
        
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(1000);
            WriteLine($"[LJ2] pt{i}_done. [{Thread.CurrentThread.ManagedThreadId}]");
        }
        WriteLine($"[LJ2] job_done.[{Thread.CurrentThread.ManagedThreadId}]");
    }

}

