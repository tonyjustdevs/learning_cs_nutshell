using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, T3_SharedFields!");
        WriteLine("[mn_1] tc._ssf: {0} [tid: {1}]"
                    , TestClass._shared_static_fld
                    , Thread.CurrentThread.ManagedThreadId);

        ThreadStart ts = () => 
        {
            if (!TestClass._shared_static_fld)
            {
                TestClass._shared_static_fld = true;
                WriteLine("[mn_2]  tc._ssf: {0} [tid: {1}]"
                    , TestClass._shared_static_fld
                    , Thread.CurrentThread.ManagedThreadId);
            }
        };

        ts();

        new Thread(ts).Start();

        WriteLine("[mn_3] tc._ssf: {0} [tid: {1}]"
                    , TestClass._shared_static_fld
                    , Thread.CurrentThread.ManagedThreadId);
    }
}

public class TestClass
{
    public static bool _shared_static_fld = false;
}
