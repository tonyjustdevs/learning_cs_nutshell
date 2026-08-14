using System.Security.Cryptography;
using static System.Console;
//using System.Linq;
//using System.Linq.Async;
partial class Program
{
    async static Task Main(string[] args)
    {
        WriteLine("[mn_1] Gday, AF2_IAsyncEnumeration!\n");


        // create query from GetIntDataAsync()

        //var query = from i in GetIntDataAsync()
        //            select i;
        //await foreach (var item in GetIntDataAsync())
        //{
        //    WriteLine($"received data: {item}");
        //}

        IAsyncEnumerable<int> query =
            from i in GetIntDataAsync()
            //where i % 2 == 0
            select i;

        await foreach (var item in query)
        {
            WriteLine($"recieved: {item}");
        }

        

        WriteLine("\n[mn_2] Goodbye, AF2_IAsyncEnumeration!");
    }
}
