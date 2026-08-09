using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T1_TaskCompSrc!");

        // [1] create a tcs
        TaskCompletionSource<int> tcs = new();

        // [2] set the result
        tcs.SetResult(42);

        // [3] get the task.result
        WriteLine("tcs.Task.Result :{0}",tcs.Task.Result);
    }
}
