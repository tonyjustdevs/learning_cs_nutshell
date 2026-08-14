using static System.Console;

partial class Program
{
    async static Task Main(string[] args)
    {
        WriteLine("Hello, AF1_LambdaFns!");
        WriteLine($"[mn_1][{Thread.CurrentThread.ManagedThreadId}]: Hello, AF1_LambdaFns!");


        //await PrintArrData();
        await foreach (var item in GetArrDataIEAsync())
        {
            WriteLine($"[mn_2][{Thread.CurrentThread.ManagedThreadId}]: {item}");
        }


        WriteLine($"[mn_3][{Thread.CurrentThread.ManagedThreadId}]: Program Ended!");

    }
}


// add get_data named-method: sync
// add get_data lambda-method: sync