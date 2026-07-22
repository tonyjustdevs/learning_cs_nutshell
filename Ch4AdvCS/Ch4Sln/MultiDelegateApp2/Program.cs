using System.IO.Enumeration;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday MultiDGApp2!");
        //DGProgressPrinter? dg_instance=null;
        //dg_instance += Utils.WTConsole; // delegate calls WTC
        //dg_instance += Utils.WTFile; // dg calls WTF
        //HardWork.LongAssJob(dg_instance);


        //DG_IntTransformer? dg_int_tranformer=null;
        //dg_int_tranformer += MathUtils.Doubler;
        //HardWork.IntArrLongJob([1, 2, 3, 4, 5], dg_int_tranformer);


        //DG_TTransformer<int> dg_t = new DG_TTransformer<int>(MathUtils.Tripler);
        //DG_TTransformer<int> dg_t2 = MathUtils.Tripler;

        HardWork.TArrLongJob([2, 4, 6, 8, 10], MathUtils.Tripler);
        
        
        //dg_t += MathUtils.Tripler;
        //HardWork.TArrLongJob([2, 4, 6, 8, 10], dg_t);
    }
}

// 1.  add DG    <void,str>
delegate void DG_ProgressPrinter(int pct);
delegate int DG_IntTransformer(int pct);
delegate T DG_TTransformer<T>(T t);

class MathUtils
{
    internal static int Doubler(int x) => x * x;
    internal static int Tripler(int x) => x * x * x;
}
class Utils
{
    static string filename = "progress.txt";
    // 2a. add Meth1  <void,str>
    internal static void WTConsole(int pct) => WriteLine($"{pct}%");
    internal static void ClearFile()
    {
        File.WriteAllText(filename, null);
    }
    internal static void WTFile(int pct)   
    {
        File.AppendAllText(filename, $"{pct}% (UT.WTFile)\n");
    }
}

class HardWork
{
    public static void LongAssJob(DG_ProgressPrinter? dg_pp)
    {
        Utils.ClearFile();

        for (int i = 0; i < 11; i++)
        {
            dg_pp?.Invoke(i * 10); // delegate gets called 10-times
            Thread.Sleep(100);
        } 
    }
    public static void IntArrLongJob(int[] arr, DG_IntTransformer dg_dd)
    {
        //Utils.ClearFile();
        string arr_str = string.Join(" ", arr);
        WriteLine($"pre: {arr_str}");
        for (int i = 0; i < arr.Length; i++)
        {

            arr[i]= dg_dd.Invoke(arr[i]); // delegate gets called 10-times
            Thread.Sleep(100);
        }
        arr_str = string.Join(" ", arr);
        WriteLine($"pst: {arr_str}");
    }
    public static void TArrLongJob<T>(T[] Tarr, DG_TTransformer<T> dg_t)
    {
        string arr_str = string.Join(" ", Tarr);
        WriteLine($"pre: {arr_str}");
        for (int i = 0; i < Tarr.Length; i++)
        {
            Tarr[i] = dg_t.Invoke(Tarr[i]);
            Thread.Sleep(100);
        }
        arr_str = string.Join(" ", Tarr);
        WriteLine($"pst: {arr_str}");
    }

}

// 1.  add DG       <int,int>
// 2.  add DBlr     <int,int>
// 3.  add [DG_instance] + assign to Dblr method
// 4.  add loop-simulation + run DG_instance(int)



// 1.  add DG    <void,str>
// 2a. add Meth1  <void,str>
// 2b. add Meth2  <void,str>
// 3.  add [DG_instance]
// 3a. add Meth1 to [DG_instance]
// 3b. add Meth2 to [DG_instance]

// 4a. add DG with Generic Types
// 4b. do above
