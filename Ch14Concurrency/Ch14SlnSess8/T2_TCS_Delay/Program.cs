using static System.Console;

internal class Program
{
    //static Action IDoNothing();
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        var task = TonysDelay(2000);
        task.GetAwaiter()
            .OnCompleted(() => WriteLine("completedddd..."));


        var task2 = Task.Delay(3000);
        //task2.get

        ReadLine();
        Task TonysDelay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object?>();
            Task task = tcs.Task;
            
            var timer = new System.Timers.Timer(milliseconds) { AutoReset = false };

            //timer.Elapsed += delegate
            //{
            //    timer.Dispose();
            //    tcs.SetResult(null);
            //};
            timer.Elapsed += delegate
            {
                timer.Dispose();
                tcs.SetResult(null);
            };

            timer.Start();

            return task;
        }
    }
}
