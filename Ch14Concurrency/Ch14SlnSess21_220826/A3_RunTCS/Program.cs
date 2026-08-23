using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, A3_RunTCS!");

        try
        {
            var task = Run(SomeIntMethod);
            //var task = Run(SomeStrMethod);
            // a hot task creating a background long-cpu-task
            // will end immediately without await.
            WriteLine($"task.Result: {task.Result}");
            
            //WriteLine($"task.Result: {await task}");
            

        }
        catch (Exception ex)
        {
            WriteLine($"ex: {ex.Message} [{ex.GetType()}]");
        }
        finally 
        { 
            WriteLine("program ended!");
        }



    }
    static int SomeIntMethod()
    {
        throw new InvalidOperationException("you fucked up!");
    }
    static string SomeStrMethod() => "42";

    static Task<int> Run(Func<int> some_function)
    {
        TaskCompletionSource<int> cts = new();

        var t = new Thread(() =>
        {
            try
            {
                Thread.Sleep(3000); // [1] simulate i/o job
                int io_result = some_function(); // [2] receive i/o result
                cts.SetResult(io_result);
            }
            catch (Exception ex)
            {
                WriteLine("exception happened & set!");
                cts.SetException(ex);
            }
            finally
            {

                WriteLine("i/o thread finally finished...");
            }
            WriteLine("i/o thread completed...");
        })
        { IsBackground = true};

        t.Start();

        return cts.Task; // [3] return task
    }
}
