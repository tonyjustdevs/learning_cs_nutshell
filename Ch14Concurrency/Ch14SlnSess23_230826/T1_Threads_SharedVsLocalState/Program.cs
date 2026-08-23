using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("[mn_1] T1_Threads_SharedVsLocalState!");
        bool _shared_done = false;
        ThreadStart ts = () =>
        {
            if (!_shared_done)
            {
                _shared_done = true;
                WriteLine("_shared_done: {0} [tid: {1}]", 
                    _shared_done
                    ,Thread.CurrentThread.ManagedThreadId);
            }
        };

        new Thread(ts).Start();
        ts();
    }
}
