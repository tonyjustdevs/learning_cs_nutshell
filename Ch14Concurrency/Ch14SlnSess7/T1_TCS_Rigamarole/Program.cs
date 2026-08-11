using System.Diagnostics.CodeAnalysis;
using System.Timers;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        var task =GetAnsToLife();

        var awaiter =task.GetAwaiter();
        WriteLine("awaiter.GetType() object '{0}' obtained", awaiter.GetType());
        WriteLine("awaiter.IsCompleted: {0}", awaiter.IsCompleted);

        awaiter.OnCompleted(() =>
        {
            WriteLine("awaiter.IsCompleted: {0}", awaiter.IsCompleted);
            WriteLine("awaiter.GetResult(): {0}", awaiter.GetResult());
        });

        ReadLine();
        Task<int> GetAnsToLife()
        {
            // [1] create a tcs
            TaskCompletionSource<int> tcs = new();
        
            // [2] add timer: no auto-reset
            var timer = new System.Timers.Timer(3000) { AutoReset = false };

            // [3a] add event:
            timer.Elapsed += delegate
            {
                timer.Dispose();
                tcs.SetResult(42);                          // [3b] add dispose()
                WriteLine("result is ready!");              // [3c] add task.SetResult()
            };

            // [4] start timer
            timer.Start();

            // [5] return tcs.task
            return tcs.Task;
        }
    }
}
// timer defaults
//  _interval = 100;
//  _enabled = false;
//  _autoReset = true;
//  _initializing = false;
//  _delayedEnable = false;
//  _callback = new TimerCallback(MyTimerCallback);