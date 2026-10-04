using static Program;
using static System.Console;

internal class Program
{
    public delegate void ProgressReporter_voidint(int percent);
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        //LocalHardWork(WriteProgressToConsole);    // v1
       

        //ProgressReporter_voidint p = new(WriteProgressToConsole);
        Action<int> p = new(WriteProgressToConsole);
        p += WriteProgressToFile;

        //LocalHardWork(p);                           // v2
        LocalHardWork2(p);
        // local methods
        void WriteProgressToConsole(int percent) => WriteLine($"{percent * 10}% completed");
        void WriteProgressToFile(int percent)
        {
            string line = $"{percent * 10}% completed\n";
            File.WriteAllText("complete.txt", line);
        }

       void LocalHardWork(ProgressReporter_voidint? pr_dg)
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);      // a. write method: cpu bound - long to execute.
                pr_dg?.Invoke(i);       // WriteLine($"{i*10}% completed");
            }
        }

        void LocalHardWork2(Action<int>? pr_dg)
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);      // a. write method: cpu bound - long to execute.
                pr_dg?.Invoke(i);       // WriteLine($"{i*10}% completed");
            }
        }

    }
}
