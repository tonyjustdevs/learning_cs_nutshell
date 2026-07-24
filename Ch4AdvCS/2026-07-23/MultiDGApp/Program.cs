using static System.Console;
using static System.IO.File;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Multi-DG-App");

        //TTTransform<int> dg_tt_instance = Meth.Doubler;
        //int[] arr = { 1, 2, 3, 4, 5 }; 
        //Utils.DoMeth(arr, dg_tt_instance);
        //WriteLine(string.Join(" ", arr));

        Action<int> pr2 = Results.WTConsole;
        //Utils.LongTask(pr2);
        ProgressRecorder pr = Results.WTConsole;
        //Utils.LongTask(pr);

        //Convert T Transform to Func<>
        Func<int, int> func_dg_intint = Meth.Squarer;
        int[] arr = [2, 4, 6, 8, 10];
        Utils.DoMeth(arr,func_dg_intint);
        WriteLine(string.Join(" ", arr));

        TTTransform<int> txformer = Meth.Halfer;
        Utils.DoMeth<int>(arr, txformer);
        WriteLine(string.Join(" ", arr));

        Func<int, int, int> txfrmer_v2 = Meth.Divider;

        Utils.DoMeth(arr, txfrmer_v2, m:2);
        WriteLine(string.Join(" ", arr)); 
    }
}

class Meth
{
    public static int Squarer(int x) => x * x;
    public static int Halfer(int x) => x / 2;
    public static int Divider(int x, int m) => x / m;
}

delegate void ProgressRecorder(int percent);
delegate T TTTransform<T>(T tval);
class Utils
{
    public static void LongTask(Action<int> pr)
    {
        for (int i = 0; i < 22; i++)
        {
            pr(i * 5);
            Thread.Sleep(50);
        }
    }

    public static void LongTask(ProgressRecorder pr)
    {
        for (int i = 0; i < 11; i++)
        {
            pr(i*10);
            Thread.Sleep(150);
        }
    }

    public static void DoMeth<T>(T[] tarr, TTTransform<T> t)
    {
        for (int i = 0; i < tarr.Length; i++)
        {
            tarr[i] = t(tarr[i]);
            Thread.Sleep(150);
        }
    }
    public static void DoMeth(int[] int_arr, Func<int,int> func_dg_intint)
    {
        for (int i = 0; i < int_arr.Length; i++)
        {
            int_arr[i] = func_dg_intint(int_arr[i]);
            Thread.Sleep(150);
        }
    }
    public static void DoMeth(int[] int_arr, Func<int, int, int> func_dg_intint,in int m)
    {
        for (int i = 0; i < int_arr.Length; i++)
        {
            int_arr[i] = func_dg_intint(int_arr[i],m);
            Thread.Sleep(150);
        }
    }

}

class Results
{
    internal static void WTConsole(int percent) => WriteLine($"{percent}%");
    internal static void WTFile(int percent)
    {
        File.AppendAllText("progress.txt", $"{percent}%\n");
    }
}
// 1.  add long task
// 1a. add class
// 1b. add method

