using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, T5_FGBG!");
        var t = new Thread(() => ReadLine());
        t.Start();
        if (args.Length>0)
        {   // if args, [new_thread] is background
            t.IsBackground = false;
            foreach (var arg in args)
            {
                WriteLine(arg);
            }
        }
        WriteLine("main end");
    }
}
