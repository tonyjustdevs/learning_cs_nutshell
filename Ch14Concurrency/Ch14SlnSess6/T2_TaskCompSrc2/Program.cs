using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("[mn_1] Hello, T2_TaskCompSrc2!");
        TaskCompletionSource<int> tcs_int = new();  // [0]  [mn_thread] create tcs
        new Thread(() =>
        {                                           // [1]  [bg_thread] simulate background thread:
            WriteLine("[bg_1] doing i/o task...");
            Thread.Sleep(2000);                     // [2]  [bg_thread] thread simulates delay
            WriteLine("[bg_2] completed i/o task...");     // [3a] [bg_thread] notification received, 
            tcs_int.SetResult(69);                  // [3b] [bg_thread]  set the result
        })
        { IsBackground = true }.Start();

        WriteLine($"[mn_2] tcs_int.Task.Result: {tcs_int.Task.Result}");
        // [4] [mn_thread] display results
    }
}
