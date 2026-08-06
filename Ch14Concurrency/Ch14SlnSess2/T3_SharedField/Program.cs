using System.Linq.Expressions;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T3_SharedFieldApp!");

        new Thread(new TestThreadCls().CheckSharedField).Start();
        new TestThreadCls().CheckSharedField();

    }
}


class TestThreadCls
{
    public static bool _sharedField = false;

    public TestThreadCls()
    {
    }

    public void CheckSharedField()
    {
        if (!_sharedField)
        {
            _sharedField = true;
            WriteLine("_sharedField: {0}",_sharedField);
        }
    }
}