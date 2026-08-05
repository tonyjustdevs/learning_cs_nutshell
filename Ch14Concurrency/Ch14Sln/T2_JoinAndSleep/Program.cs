using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello T2-Join-And-Sleep");
        Thread t = new(WriteY);
        t.Start();
        Thread.Sleep(100);
        WriteLine($"t.ThreadState: {(int)t.ThreadState} (y in main)");
        bool blocked = (t.ThreadState & ThreadState.WaitSleepJoin) != 0;
        // bit flag comparison
        // - lets assume t.tstate is 0100
        // - compare v WaitSleepJoin 0100
        // - matching ---> ie =/= 0 ---> true
        // - at least WSJ is true
        t.Join();
    }

    static void WriteY()
    {

        WriteLine($"t.ThreadState: {(int)Thread.CurrentThread.ThreadState} (y in y: pre-sleep)");
        Thread.Sleep(500);
        WriteLine($"t.ThreadState: {(int)Thread.CurrentThread.ThreadState} (y in y: pst-sleep)");
        for (int i = 0; i < 1000; i++)
        {
            Write("y"); 
        } 
    }


    // 1. create a thread
    // 2. start
    // 3. join
    // 4. output completed
}

