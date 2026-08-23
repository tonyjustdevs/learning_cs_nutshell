using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, T2_ThreadStart_SharedState!");
        bool _shared_state = false;
        ThreadStart ts = () =>
        {
            if (!_shared_state)
            {
                _shared_state = true;
                WriteLine("_shared_state: {0}", _shared_state);
            }
        };
        ts();
        new Thread(ts).Start();
    }
}
