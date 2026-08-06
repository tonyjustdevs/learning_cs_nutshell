using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T2_ExceptionHandling!");
        Go();                       // both handled
        new Thread(Go).Start();     // both handled

        void Go() {

            try
            {
                throw null;
                //new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                WriteLine("error_handled: {0} [{1}]", ex.Message, ex.GetType());
            }
        }
    }
}
