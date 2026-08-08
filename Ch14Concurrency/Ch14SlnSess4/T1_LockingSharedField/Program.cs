using System.Globalization;
using System.Runtime.InteropServices;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T1_LockingSharedField!");
        bool sharedVariable = false;
        
        new Thread(Go).Start();
        Go();

        void Go()
        {
            if (!sharedVariable)
            {
                sharedVariable = true;
                WriteLine("done");
            }
        }
    }
}

class ThreadSafe
{
    public bool sharedField = false;

    public void Go()
    {
        if (!sharedField)
        {
            sharedField = true;
            WriteLine("done!");
        }
    }
}
