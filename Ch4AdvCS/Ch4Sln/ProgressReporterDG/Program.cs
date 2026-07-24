using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Progress-Reporter!");
        ProgressReporter p = Write_To_Console;
        p += Write_To_File;
        p(0);
        p(50);
        p(100);

    }
    public static void Write_To_Console(int pct) => WriteLine($"{pct}% completed.");
    public static void Write_To_File(int pct) {
        System.IO.File.WriteAllText("progress.txt", pct.ToString());
        WriteLine($"{pct}% completed.\n"); }
}

delegate void ProgressReporter(int percent_completed);

// add void DG(int)
// add void meth1(int): write to CS
// add void meth2(int): write to File
// add dg_obj -> meth1 += meth2
// add Util cls
// add Util static method(DG dg_obj)
