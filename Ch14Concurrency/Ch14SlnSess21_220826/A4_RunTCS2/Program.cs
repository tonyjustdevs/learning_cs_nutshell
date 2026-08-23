using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        //int SomeIOBoundIntMethod() => 69;
        int SomeIOBoundIntMethod2()=> throw new OperationCanceledException("you fked up!!");

        try
        {
            WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]Hello, A4_RunTCS2!");
            var hot_io_task = Run(SomeIOBoundIntMethod2);
            WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]io_task result: {await hot_io_task}");

        }
        catch (Exception ex)
        {
            WriteLine($"error handled in main: {ex.Message} [{ex.GetType()}]");
        }

        WriteLine("program completed.");
    }

    static Task<int> Run(Func<int> function_io_bound)
    {
        TaskCompletionSource<int> tcs = new(); // [1] adds settable task

        var t = new Thread(() =>
        {
            try // [2] run i/o bound method
            {
                WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] new thread started...");
                Thread.Sleep(3000);
                var io_result = function_io_bound();
                if (tcs.TrySetResult(io_result))
                {
                    WriteLine($"[{Thread.CurrentThread.ManagedThreadId}][Run()] got new result!");
                }
                else
                {
                    WriteLine($"[{Thread.CurrentThread.ManagedThreadId}][Run()] cannot reset result!");
                }

            }
            catch (Exception ex)
            {
                if (tcs.TrySetException(ex))
                {
                    WriteLine($"[{Thread.CurrentThread.ManagedThreadId}][Run()] new exception occurred!");
                }
                else
                {
                    WriteLine($"[{Thread.CurrentThread.ManagedThreadId}][Run()] exception occurred again!");
                }
            }
        })
        { IsBackground=true };

        t.Start();

        return tcs.Task;
    }
}
