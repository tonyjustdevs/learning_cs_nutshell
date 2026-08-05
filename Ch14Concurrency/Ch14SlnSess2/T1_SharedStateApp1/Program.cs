using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T1_SharedStateApp1!");

        bool _shared_switch = false;

        new Thread(Local_Go).Start();
        Local_Go();
        void Local_Go()
        {
            if (!_shared_switch)
            {
                _shared_switch = true;
                WriteLine("shared_switch: {0}", _shared_switch);
            }
        }
    }

}

// start two threads with a shared state

