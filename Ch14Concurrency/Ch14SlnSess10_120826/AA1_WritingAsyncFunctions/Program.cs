using System.Timers;
using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        
        WriteLine($"[mn_1_1] hello AA1_WritingAsyncFunctions! [{Thread.CurrentThread.ManagedThreadId}]");

        await Go();

        WriteLine($"[mn_2_8] program ending! [{Thread.CurrentThread.ManagedThreadId}]");

        async Task Go()
        {
            WriteLine($"[go_1_2] began... [{Thread.CurrentThread.ManagedThreadId}]");
            await PrintAnsToLife();
            WriteLine($"[go_1_7] ends... [{Thread.CurrentThread.ManagedThreadId}]");
        }

        async Task PrintAnsToLife() 
        { 
            WriteLine($"[pa_1_3] began... [{Thread.CurrentThread.ManagedThreadId}]");
            int ans = await GetAnsToLife();
            WriteLine($"[pa_2_6] ends: {ans} [{Thread.CurrentThread.ManagedThreadId}]");
        }
        
        async Task<int> GetAnsToLife()
        {
            WriteLine($"[ga_1_4] began... [{Thread.CurrentThread.ManagedThreadId}]");
            await Task.Delay(1000);

            throw new InvalidOperationException();
            
            WriteLine($"[ga_2_5] ends... [{Thread.CurrentThread.ManagedThreadId}]");
            return 42;
        }
    }
}
//Time ───────────────────────────────>

//task1:  █████████████████
//task2:                   █████████████████


