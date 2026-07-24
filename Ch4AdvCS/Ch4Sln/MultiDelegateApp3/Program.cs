using static System.Console;

delegate void DG_ProgressReporter(int pct);
delegate T DG_TT_Txform<T>(T tval);

internal class Box<T> { }
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Multi-Delegate-App 3");
        int[] values = { 1, 2, 3 };
        Utils.Transform(values, Math.Double);
        foreach (var i in values)
        {
            Write($"{i} ");
        }

    }
}

internal class Math
{
    public static int Double(int x) => x * x;
}

internal class Utils
{
    public static void Transform<T>(T[] Tarr, DG_TT_Txform<T> t)
    {
        for (int i = 0; i < Tarr.Length; i++)
        {
            Tarr[i] = t(Tarr[i]);
        }
    }
    public static void HardJob(DG_ProgressReporter? p)
    {
        for (int i = 0; i < 11; i++)
        {
            p?.Invoke(i*10); // call delegate -> calls all attached methods
            Thread.Sleep(200);
        }
    }

}

internal class Progress
{
    public static void WriteToConsole(int pct) => WriteLine($"progress: {pct}%");
}