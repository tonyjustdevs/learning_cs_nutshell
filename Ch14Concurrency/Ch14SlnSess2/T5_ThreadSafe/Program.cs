using static System.Console;

internal class ThreadSafe
{
    static bool _sharedState = false;
    static readonly object _locker = new();
    static void Main(string[] args)
    {
        WriteLine("Hello, T5_ThreadSafe!");
        Thread ts = new(Go);
        ts.Start();
        Go();
    }

    static void Go()
    {
        lock(_locker)
        {
            if (!_sharedState)
            {
                WriteLine($"_sharedState: {_sharedState}");
                _sharedState = true;
            }
        }
    }
}
