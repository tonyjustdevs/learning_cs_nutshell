using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T5_Local_vs_Shared_State2!");

        bool _done = false;
        new Thread(Go).Start();
        Go();

        void Go()
        {
            if (!_done)
            {
                _done = true;
                WriteLine("done!");
            }
        }
    }



}
