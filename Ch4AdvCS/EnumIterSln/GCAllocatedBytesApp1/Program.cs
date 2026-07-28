using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello GCAllocatedBytesApp1!");

        long mems = GC.GetAllocatedBytesForCurrentThread();
        WriteLine($"pre_mem: {mems:N0}");

        //var trades = File.ReadAllLines("trades.csv");
        var tradesIE = File.ReadLines("trades.csv");

        //WriteLine(trades.Length);
        mems = GC.GetAllocatedBytesForCurrentThread();
        WriteLine($"pst_mem: {mems:N0}");
        //WriteLine($"pst_mem: {pre_mem}");


        // TEST-1: no read        
        //pre_mem: 56656
        //pst_mem: 62896

        // TEST-2: read all
        //pre_mem: 56656
        //pst_mem: 814552

        // TEST-3: read IE
        //pre_mem: 56656
        //pst_mem: 67128
    }


}

// 1. get pre-mem (before file read)
// 2. read file
// 3. get pst-mem
// 4. calc difference