using System.Numerics;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P2!");
        
        MyReporter reporter_instance = new MyReporter();        // get instance
        reporter_instance.Prefix = "%Complete: ";               // set prefix
        DGProgressReporter dg = reporter_instance.ReportProgress; // get instance method
        
        
        dg.Invoke(99);                                      // %Complete: 99
        Console.WriteLine(dg.Target == reporter_instance);  // True
        Console.WriteLine(dg.Method);                       // Void ReportProgress(Int32)


        reporter_instance.Prefix = "yummy %: ";
        dg.Invoke(99);                                      // yummy %: 99

    }
}

public delegate void DGProgressReporter(int percentComplete);


class MyReporter
{
    public string Prefix = "";

    public void ReportProgress(int percentComplete)
      => Console.WriteLine(Prefix + percentComplete);
}
