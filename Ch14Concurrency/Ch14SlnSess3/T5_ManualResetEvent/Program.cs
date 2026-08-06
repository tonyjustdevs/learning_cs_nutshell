using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T5_ManualResetEvent!");
        ManualResetEvent signal = new ManualResetEvent(false);
        WriteLine("main thread started...");
        
        new Thread(Worker).Start();

        WriteLine("main is slow...");
        
        Thread.Sleep(3000);
        
        WriteLine("main is done...");
        
        signal.Set();
        
        void Worker()
        {
            WriteLine("Worker() starting...");
            Thread.Sleep(1000);
            signal.WaitOne();
            WriteLine("Worker() resumes...");
            Thread.Sleep(1000);
        }
    }
}
// [1] add 2-threads: main & worker
// [2] [main or worker] add signal
// [3] [wrkr] signal.workone()
// [4] [main] do "work" or thread.sleep
// [5] [wrkr] signal.set()
