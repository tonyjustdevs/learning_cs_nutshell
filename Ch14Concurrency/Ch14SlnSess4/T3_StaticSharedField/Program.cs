using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T3_StaticSharedField!");
        //new Thread(Test.Go).Start();
        //Test.Go(); // donedone or just done

        //new Thread(Test.Go2).Start();
        //Test.Go2();  //donedone
        
        new Thread(Test.Go3).Start();
        Test.Go3();  //done

    }
}

class Test
{
    static bool _shared_done=false;
    static readonly object _locker = new();
    public static void Go()
    {                               
        if (!_shared_done)          // race condition possible here:
        {                           // - both calls observer (== false) 
            _shared_done = true;    // - BEFORE they updating variable
            WriteLine("done");
        }
    }

    public static void Go2()
    {
        if (!_shared_done)          
        {
            // simulate realistic delay from condition to assignment
            Thread.Sleep(50);
            _shared_done = true;    
            WriteLine("done");
        }
    }

    public static void Go3()
    {
        lock (_locker)
        {
            if (!_shared_done)
            {
                // simulate realistic delay from condition to assignment
                Thread.Sleep(50);
                _shared_done = true;
                WriteLine("done");
            }
        }
    }

}
