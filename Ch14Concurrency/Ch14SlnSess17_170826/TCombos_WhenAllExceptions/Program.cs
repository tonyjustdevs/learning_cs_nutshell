using System.Reflection;
using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, TCombos_WhenAllExceptions!");

        // [1] add 3 async tasks

        async Task<int> Delay2() { throw null; }
        async Task<int> Delay1() { await Task.Delay(1000 ); return 1; }
        //async Task<int> Delay3() { throw null; }

        //var tasks_intarr = Task.WhenAll(Delay1(), Delay2(), Delay3());
        //var all = Task.WhenAll(Delay1(), Delay2(), Delay3());
        var all = Task.WhenAll(Delay1(), Delay2());
        try
        {
            await all;
        }
        catch
        {

            var ie = all.Exception!.InnerExceptions;
            Console.WriteLine(
            $"\nWhenAll() had {ie.Count} exceptions:");

            foreach (var ex in ie)
            {
                
                WriteLine($"\n- [{ex.GetType()}]: {ex.Message} - [StackTrace: \n{ex.StackTrace}]\n");
            }
        }
        //task.
        // without ASYNC
        // [expectation] main ends instantly
        // [2] combine whenall
        // [3] throw exceptions
    }

    public static async Task Unnamed()
    {
        await Task.Delay(1000);
    }
}

//TCombos_WhenAllExceptions
