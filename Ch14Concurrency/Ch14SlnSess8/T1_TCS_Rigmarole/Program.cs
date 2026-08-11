using static System.Console;    
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var Task = Run(GetAnsToLife);

        var awaiter = Task.GetAwaiter();

        awaiter.OnCompleted(() =>
        {
            WriteLine($"awaiter.IsCompleted: {awaiter.IsCompleted}"); 
            WriteLine($"awaiter.GetResult(): {awaiter.GetResult()}"); 
        });

        ReadLine();

        int GetAnsToLife() => 42;

        Task<int> Run(Func<int> int_function)
        {
            // [1] create a tcs
            var tcs = new TaskCompletionSource<object>();
            Task task = tcs.Task;
            // [2] create a timer: 
            //  [a] + no reset
            var timer = new System.Timers.Timer(2000) { AutoReset = false };

            //  [b] + elapsed delegate:
            //   i.  + dispose timer
            //  ii.  + tsc.SetResult
            timer.Elapsed += delegate
            {
                timer.Dispose();
                tcs.SetResult(int_function());
            };
            timer.Start();
            //[3] return task
            return tcs.Task;
        }
        //Func<int> int_function2;
    }
}
