using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday MultiDelegateCallingApp!\n");

        MyDelegate mydg_instance = Utils.WriteToConsoleUT;
        mydg_instance += Utils.WriteToFileUT;
        Utils.DoLongJob(mydg_instance);
    }


    class Utils
    {
        public static void DoLongJob(MyDelegate my_dg)
        {

            WriteLine("Doing a Long Job...\n");
            ClearFileUT();
            for (int i = 0; i <= 10; i++)
            {
                my_dg(i*10);
                Thread.Sleep(200);
            }
        }
        public static void WriteToConsoleUT(int progress) => WriteLine($"- {progress}% (Utils.WTCUT))");
        
        public static void ClearFileUT(string filename = "progress.txt")
        {
            WriteLine("clearing file: {0}", filename);
            File.WriteAllText(filename,null);

        }
        public static void WriteToFileUT(int progress)
        {
            string filename = "progress.txt";
            //WriteLine("writing to file: {0}", filename);
            File.AppendAllText(filename, $"{progress}% (Utils.WTF))\n");
        }
           static void WriteToConsole(int progress) => WriteLine($"- {progress}%");
    }
    

}
// 1. add DG type: <void,string>
public delegate void MyDelegate(int s);

// 2. add method:  <void,string>

// 3. add [DG_instance] of method
// 4. run method in loop to call [DG_instance]
