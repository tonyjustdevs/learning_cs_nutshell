using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T3_ForegroundBackground!");

        // add app: starts new thread:
        // [1] readline() on [fg_thread] if no args
        // [2] readline() on [bh_thread] if args

        var t = new Thread(() => 
        {
            Thread.Sleep(500);
            WriteLine("i will read you: ");
            
            string? input = ReadLine();
            WriteLine("you wrote: {0}", input);
        });
        if (args.Length>0)
        {
            t.IsBackground = true;
        }
        t.Start();
        
    }
}
