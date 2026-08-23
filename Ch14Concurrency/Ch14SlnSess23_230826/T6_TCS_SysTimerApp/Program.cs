using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, T6_TCS_SysTimerApp!");
        var delay_task = DelayViaTimer();
        
        var awaiter = DelayViaTimer().GetAwaiter();
        WriteLine("delay started");
        awaiter.OnCompleted(async () =>
        {
            WriteLine("delay over");
            awaiter.GetResult();
        });

        //ReadLine();
        WriteLine("program end");


        static Task<int> GetAnsToLifeViaTimer()
        {
            TaskCompletionSource<int> tcs = new();

            System.Timers.Timer timer = new(3000) { AutoReset = false };

            timer.Elapsed += (_, _) =>
            {
                timer.Dispose();
                tcs.SetResult(42);
            };
            return tcs.Task;
        }

        static Task DelayViaTimer()
        {
            TaskCompletionSource<object> tcs = new();
            Task task = tcs.Task;
            System.Timers.Timer timer = new(3000) { AutoReset = false };

            timer.Elapsed += (_, _) =>
            {
                timer.Dispose();
                tcs.SetResult(null);
            };
            timer.Start();
            return tcs.Task;
        }
    }

}
