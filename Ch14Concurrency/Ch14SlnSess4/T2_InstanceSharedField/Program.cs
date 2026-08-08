using System.ComponentModel;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");

        var tt = new TestCls();

        new Thread(tt.DoWork).Start(); 
        tt.DoWork();
    }
}

class TestCls
{
    bool _done = false;

    public void DoWork()
    {
        if (!_done)
        {
            _done = true;
            WriteLine("done!");
        }
    }
}
