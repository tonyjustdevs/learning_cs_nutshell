using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T3_WaitSleepJoin!");
        Thread t = new(WriteX);
        t.Start();
        Thread.Sleep(100);
        var blocked = (ThreadState.WaitSleepJoin & t.ThreadState) != 0;
        WriteLine($"{t.Name} blocked status: {blocked}");
        t.Join();
    }

    static void WriteX()
    {
        Thread.Sleep(1000);
        for (int i = 0; i < 500; i++)
        {
            Write("y");
        }
    }
}

// 1. add thread
// 2. + thread sleeps
// 3. check thread_state
// 4. confirm thread_state is sleeping