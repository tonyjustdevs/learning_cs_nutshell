using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        
        WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Hello, AF1_AsyncAwait!");
        // [thd_1] calls (enters) Main
        // [thd_1] calls GetDataAsync()
        //DisplayDataAsync();
        WriteLine("i believe i can do stuff as well");
        WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Goodbye! ");
    }

    static async Task DisplayDataAsync()
    {
        WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] DisplayDataAsync() starting (pre-await)");
        var returned_data = await GetDataAsync();
        WriteLine($"data: {returned_data}");
        WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] DisplayDataAsync() ending (pst-await)");
    }


    static async Task<string> GetDataAsync()
    {
        WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] GetDataAsync() starting (pre-await)");
        await Task.Delay(1000); // [thd_1] reaches awaitable Task

        WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] GetDataAsync() ending (pst-await)");
        return "hello data!";
    }
}


// add task<string> returns after delay