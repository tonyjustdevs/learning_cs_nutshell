using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T5_TaskCompletionSource!");

        var tcs = new TaskCompletionSource<int>();

        var task = tcs.Task;
        WriteLine($"[pre] task.Status: {task.Status}");
        tcs.SetResult(42);
        WriteLine($"[pst] task.Status: {task.Status}");
        WriteLine($"[pst] task.Result: {task.Result}");
        
        ReadLine();
        
    }
}
